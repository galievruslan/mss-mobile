using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class RoutePresenter : IPresenter<RouteViewModel>, IListPresenter<RoutePointViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        private readonly IRouteView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IModelsFactory _modelsFactory;
        private readonly INavigator _navigator;

        private IDataPageRetriever<RoutePoint> _routePointRetriever;
        private Cache<RoutePoint> _cache;

        private readonly IDictionary<int, Color> _statusColorDictionary =
            new Dictionary<int, Color>();

        public RoutePresenter(IRouteView view, 
                              IUnitOfWorkFactory unitOfWorkFactory,
                              IRepositoryFactory repositoryFactory, 
                              IModelsFactory modelsFactory,
                              IConfigurationManager configurationManager,
                              INavigator navigator,
                              RouteViewModel routeViewModel) {
            _repositoryFactory = repositoryFactory;
            _modelsFactory = modelsFactory;
            _navigator = navigator;
            _unitOfWorkFactory = unitOfWorkFactory;
            _view = view;
            _viewModel = routeViewModel;

            var statusRepository = _repositoryFactory.CreateRepository<Status>();
            foreach (var status in statusRepository.Find().ToArray()) {
                try {
                    var colorName = configurationManager.GetConfig("Domain")
                                                        .GetSection("Statuses")
                                                        .GetSetting(status.Name)
                                                        .Value;
                    _statusColorDictionary.Add(status.Id, ColorHelper.StringToColor(colorName));
                }
                catch (Exception exception) {
                    Log.Error(exception);
                }
            }
        }

        public int InitializeListSize() {
            return _routePointRetriever.Count;
        }

        public RoutePointViewModel GetItem(int index) {
            RoutePoint item = _cache.RetrieveElement(index);
            Color color = Color.Empty;
            if (_statusColorDictionary.ContainsKey(item.StatusId))
                color = _statusColorDictionary[item.StatusId];
            
            return new RoutePointViewModel {
                Id = item.Id,
                ShippinAddressName = item.ShippingAddressName,
                ShippinAddressAddress = item.ShippingAddressAddress,
                StatusId = item.StatusId,
                StatusName = item.StatusName,
                Color = color
            };
        }

        private RoutePoint _selectedRoutePoint;
        public void Select(int index) {
            _selectedRoutePoint = _cache.RetrieveElement(index);
        }

        public RoutePointViewModel SelectedModel {
            get {
                Color color = Color.Empty;
                if (_selectedRoutePoint != null && _statusColorDictionary.ContainsKey(_selectedRoutePoint.StatusId))
                    color = _statusColorDictionary[_selectedRoutePoint.StatusId];

                return _selectedRoutePoint != null
                           ? new RoutePointViewModel {
                               Id = _selectedRoutePoint.Id,
                               RouteId = _selectedRoutePoint.RouteId,
                               StatusId = _selectedRoutePoint.StatusId,
                               StatusName = _selectedRoutePoint.StatusName,
                               ShippinAddressName = _selectedRoutePoint.ShippingAddressName,
                               ShippinAddressAddress = _selectedRoutePoint.ShippingAddressAddress,
                               Color = color
                           }
                           : null;
            }
        }

        private readonly RouteViewModel _viewModel;
        public RouteViewModel Initialize() {
            if (_viewModel.Id == 0) {
                var routeRepository = _repositoryFactory.CreateRepository<Route>();
                var route =
                    routeRepository.Find()
                                   .Where(new RouteOnDateSpec(_viewModel.Date))
                                   .FirstOrDefault();
                if (route != null) {
                    _viewModel.Id = route.Id;
                    _viewModel.Date = route.Date;
                }
            }

            GetRouteOnDate();
            return _viewModel;
        }

        public void GetRouteOnDate() {
            var routeRepository = _repositoryFactory.CreateRepository<Route>();
            var route =
                routeRepository.Find().Where(new RouteOnDateSpec(_viewModel.Date)).FirstOrDefault();
            _routePointRetriever = new RoutePointRetriever(route);
            _cache = new Cache<RoutePoint>(_routePointRetriever, 10);

            if (route != null) {
                _viewModel.Id = route.Id;
            }
        }

        public void CreateRouteOnDate() {
            var routeRepository = _repositoryFactory.CreateRepository<Route>();
            var route =
                routeRepository.Find().Where(new RouteOnDateSpec(_viewModel.Date)).FirstOrDefault();
            if (route != null)
                return;

            route = _modelsFactory.CreateRoute(_viewModel.Date);
            var routeTemplateRepository = _repositoryFactory.CreateRepository<RouteTemplate>();
            var routeTemplate =
                routeTemplateRepository.Find()
                                       .Where(new RouteTemplateByDayOfWeekSpec(_viewModel.Date.DayOfWeek))
                                       .FirstOrDefault();

            var shippingAddressRepository =
                _repositoryFactory.CreateRepository<ShippingAddress>();
            var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();
            var statusRepository = _repositoryFactory.CreateRepository<Status>();
            var defaultStatus = statusRepository.Find().FirstOrDefault();

            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                unitOfWork.BeginTransaction();
                route = routeRepository.Save(route);

                if (routeTemplate != null) {
                    foreach (var pointTemplate in routeTemplate.PointTemplates.ToArray()) {
                        RoutePoint routePoint = route.CreatePoint();
                        ShippingAddress shippingAddress =
                            shippingAddressRepository.GetById(pointTemplate.ShippingAddressId);

                        if (shippingAddress != null) {
                            routePoint.SetShippingAddress(shippingAddress);
                            routePoint.SetStatus(defaultStatus);
                            routePointRepository.Save(routePoint);
                        }
                    }
                }

                unitOfWork.Commit();
            }

            if (routeTemplate == null) {
                _view.ShowInformation("Route template not found. Empty route created.");
            }
        }

        public void GoToAddRoutePoint() {
            _navigator.GoToNewRoutePoint(_viewModel);
        }

        public void DeleteRoutePoint() {
            if (_selectedRoutePoint != null) {
                var routePointRepository = _repositoryFactory.CreateRepository<RoutePoint>();
                var routePoint = routePointRepository.GetById(_selectedRoutePoint.Id);
                if (routePoint.Orders.GetCount() > 0 || routePoint.Synchronized) {
                    _view.ShowError(new[] {"You can't delete synchronized route point or point with orders!"});
                }
                else {
                    using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                        try {
                            unitOfWork.BeginTransaction();
                            routePointRepository.Delete(routePoint);
                            unitOfWork.Commit();
                            _selectedRoutePoint = null;
                        }
                        catch (Exception exception) {
                            Log.Error(exception);
                            unitOfWork.Rollback();
                        }
                    }
                }
            }
        }

        public void GoToOrderList() {
            if (SelectedModel != null)
                _navigator.GoToRoutePointsOrderList(SelectedModel);
        }

        public void GoToCreateOrder() {
            if (SelectedModel != null)
                _navigator.GoToCreateOrderForRoutePoint(SelectedModel);
        }

        public void GoToMenuView() {
            _navigator.GoToMenu();
        }

        public void GoToStatusChanging() {
            if (SelectedModel != null)
                _navigator.GoToChangeStatus(SelectedModel);
        }
    }
}
