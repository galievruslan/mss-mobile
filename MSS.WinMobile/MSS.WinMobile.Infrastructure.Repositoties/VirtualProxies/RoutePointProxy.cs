﻿using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class RoutePointProxy : RoutePoint {
        private IStorageRepository<Order> _ordersRepository;
        public RoutePointProxy(IStorageRepository<Order> ordersRepository) {
            _ordersRepository = ordersRepository;
        }
        
        public RoutePointProxy(Route route, IStorageRepository<Order> ordersRepository)
            : base(route) {
            _ordersRepository = ordersRepository;
        }

        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public int RouteId
        {
            get { return base.RouteId; }
            set { base.RouteId = value; }
        }

        new public int ShippingAddressId
        {
            get { return base.ShippingAddressId; }
            set { base.ShippingAddressId = value; }
        }

        new public string ShippingAddressName
        {
            get { return base.ShippingAddressName; }
            set { base.ShippingAddressName = value; }
        }

        new public int StatusId
        {
            get { return base.StatusId; }
            set { base.StatusId = value; }
        }

        public override IQueryObject<Order> Orders {
            get {
                var routePointsOrders = new RoutePointsOrdersSpec(this);
                return _ordersRepository.Find().Where(routePointsOrders);
            }
        }
    }
}