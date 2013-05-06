using System;
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

        public RoutePresenter(IRouteView view, IUnitOfWorkFactory unitOfWorkFactory, IRepositoryFactory repositoryFactory, IModelsFactory modelsFactory) {
            _repositoryFactory = repositoryFactory;
            _modelsFactory = modelsFactory;
            _unitOfWorkFactory = unitOfWorkFactory;
            _view = view;
        }

        private RoutePoint _selectedRoutePoint;
        public void SelectItem(int index) {
            _selectedRoutePoint = _cache.RetrieveElement(index);
        }

        public int InitializeListSize() {
            GetRouteOnDate();
            return _routePointRetriever.Count;
        }

        public RoutePointViewModel GetItem(int index) {
            RoutePoint item = _cache.RetrieveElement(index);
            return new RoutePointViewModel
            {
                ShippinAddressName = item.ShippingAddressName
            };
        }

        private RouteViewModel _viewModel;
        public RouteViewModel Initialize() {
            _viewModel = new RouteViewModel {
                Date = DateTime.Now
            };
            return _viewModel;
        }

        public void GetRouteOnDate() {
            var routeRepository = _repositoryFactory.CreateRepository<Route>();
            var route =
                routeRepository.Find().Where(new RouteOnDateSpec(_viewModel.Date)).FirstOrDefault();
            _routePointRetriever = new RoutePointRetriever(route);
            _cache = new Cache<RoutePoint>(_routePointRetriever, 10);
        }

        public void CreateRouteOnDate() {
            var routeRepository = _repositoryFactory.CreateRepository<Route>();
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
                var route = _modelsFactory.CreateRoute(_viewModel.Date);
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
    }
}
