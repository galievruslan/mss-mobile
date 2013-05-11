using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;
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

        private IDataPageRetriever<RoutePoint> _routePointRetriever;
        private Cache<RoutePoint> _cache;

        public RoutePresenter(IRouteView view, IUnitOfWorkFactory unitOfWorkFactory,
                              IRepositoryFactory repositoryFactory, IModelsFactory modelsFactory) {
            _repositoryFactory = repositoryFactory;
            _modelsFactory = modelsFactory;
            _unitOfWorkFactory = unitOfWorkFactory;
            _view = view;
        }

        public int InitializeListSize() {
            return _routePointRetriever.Count;
        }

        public RoutePointViewModel GetItem(int index) {
            RoutePoint item = _cache.RetrieveElement(index);
            return new RoutePointViewModel {
                Id = item.Id,
                ShippinAddressName = item.ShippingAddressName
            };
        }

        private RoutePoint _selectedRoutePoint;
        public void Select(int index) {
            _selectedRoutePoint = _cache.RetrieveElement(index);
        }

        public RoutePointViewModel SelectedModel {
            get {
                return _selectedRoutePoint != null
                           ? new RoutePointViewModel {
                               Id = _selectedRoutePoint.Id,
                               ShippinAddressName = _selectedRoutePoint.ShippingAddressName
                           }
                           : null;
            }
        }

        private RouteViewModel _viewModel;
        public RouteViewModel Initialize() {
            _viewModel = new RouteViewModel {
                Date = DateTime.Now
            };

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

                        routePoint.SetShippingAddress(shippingAddress);
                        routePoint.SetStatus(defaultStatus);
                        routePointRepository.Save(routePoint);
                    }
                }

                unitOfWork.Commit();
            }
        }

        public bool AddRoutePoint() {
            var routeRepository = _repositoryFactory.CreateRepository<Route>();
            var route =
                routeRepository.Find().Where(new RouteOnDateSpec(_viewModel.Date)).FirstOrDefault();

            if (route == null) {
                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                    unitOfWork.BeginTransaction();
                    route = _modelsFactory.CreateRoute(_viewModel.Date);
                    route = routeRepository.Save(route);
                    unitOfWork.Commit();
                }
            }

            var newRoutePointView =
                NavigationContext.NavigateTo<INewRoutePointView>(
                    new Dictionary<string, object> {{"route", _viewModel}});
            if (newRoutePointView.ShowDialogView() == DialogViewResult.Ok) {
                _routePointRetriever = new RoutePointRetriever(route);
                _cache = new Cache<RoutePoint>(_routePointRetriever, 10);
                return true;
            }

            return false;
        }

        public void GoToOrderList() {
            if (SelectedModel != null) {
                var orderListView =
                    NavigationContext.NavigateTo<IOrderListView>(new Dictionary<string, object>
                        {
                            {"route_point", SelectedModel}
                        });
                orderListView.ShowView();
            }
        }
    }
}
