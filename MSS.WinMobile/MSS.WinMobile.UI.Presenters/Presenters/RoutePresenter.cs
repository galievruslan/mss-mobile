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
    public class RoutePresenter : IListPresenter<RoutePointViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        private readonly IRouteView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IModelsFactory _modelsFactory;

        private readonly IDataPageRetriever<RoutePoint> _routePointRetriever;
        private readonly Cache<RoutePoint> _cache;

        public RoutePresenter(IRouteView view, IUnitOfWorkFactory unitOfWorkFactory, IRepositoryFactory repositoryFactory, IModelsFactory modelsFactory) {
            _repositoryFactory = repositoryFactory;
            _modelsFactory = modelsFactory;
            _unitOfWorkFactory = unitOfWorkFactory;
            _view = view;

            var routeRepository = repositoryFactory.CreateRepository<Route>();
            var route =
                routeRepository.Find().Where(new RouteOnDateSpec(DateTime.Today)).FirstOrDefault();
            if (route == null) {
                var routeTemplateRepository = _repositoryFactory.CreateRepository<RouteTemplate>();
                var routeTemplate =
                    routeTemplateRepository.Find()
                                           .Where(new RouteTemplateByDayOfWeekSpec(DateTime.Today.DayOfWeek))
                                           .FirstOrDefault();

                var shippingAddressRepository =
                    _repositoryFactory.CreateRepository<ShippingAddress>();
                var routePointRepository = repositoryFactory.CreateRepository<RoutePoint>();
                var statusRepository = repositoryFactory.CreateRepository<Status>();
                var defaultStatus = statusRepository.Find().FirstOrDefault();

                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                    unitOfWork.BeginTransaction();
                    route = _modelsFactory.CreateRoute(DateTime.Today);
                    route = routeRepository.Save(route);

                    if (routeTemplate != null) {
                        foreach (var pointTemplate in routeTemplate.PointTemplates.ToArray()) {
                            RoutePoint routePoint = route.CreatePoint();
                            ShippingAddress shippingAddress =
                                shippingAddressRepository.GetById(pointTemplate.ShippingAddressId);

                            routePoint.SetShippingAddress(shippingAddress);
                            routePointRepository.Save(routePoint);
                        }
                    }
                    unitOfWork.Commit();
                }
            }

            _routePointRetriever = new RoutePointRetriever(route);
            _cache = new Cache<RoutePoint>(_routePointRetriever, 10);
        }

        private RoutePoint _selectedRoutePoint;
        public void SelectItem(int index) {
            _selectedRoutePoint = _cache.RetrieveElement(index);
        }

        public int InitializeListSize() {
            return _routePointRetriever.Count;
        }

        public RoutePointViewModel GetItem(int index) {
            RoutePoint item = _cache.RetrieveElement(index);
            return new RoutePointViewModel
            {
                ShippinAddressName = item.ShippingAddressName
            };
        }
    }
}
