using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class RouteProxy : Route
    {
        private readonly IStorageRepository<RoutePoint> _routesPointsRepository;
        private readonly IStorageRepository<Order> _ordersRepository;
        private IStorageRepository<OrderItem> _orderItemsRepository;
        public RouteProxy(IStorageRepository<RoutePoint> routesPointsRepository, IStorageRepository<Order> ordersRepository, IStorageRepository<OrderItem> orderItemsRepository) {
            _routesPointsRepository = routesPointsRepository;
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
        }

        public RouteProxy(DateTime date, IStorageRepository<RoutePoint> routesPointsRepository,
                          IStorageRepository<Order> ordersRepository,
                          IStorageRepository<OrderItem> orderItemsRepository)
            : base(date) {
            _routesPointsRepository = routesPointsRepository;
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
        }

        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public DateTime Date
        {
            get { return base.Date; }
            set { base.Date = value; }
        }

        public override IQueryObject<RoutePoint> Points {
            get {
                var routesPointsSpec = new RoutesPointsSpec(this);
                return _routesPointsRepository.Find().Where(routesPointsSpec);
            }
        }

        public override RoutePoint CreatePoint() {
            return new RoutePointProxy(this, _ordersRepository, _orderItemsRepository);
        }
    }
}
