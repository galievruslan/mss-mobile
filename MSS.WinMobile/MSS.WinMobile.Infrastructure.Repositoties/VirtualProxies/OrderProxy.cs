using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class OrderProxy : Order {
        private readonly IStorageRepository<OrderItem> _orderItemRepository;
        public OrderProxy(IStorageRepository<OrderItem> orderItemRepository) {
            _orderItemRepository = orderItemRepository;
        }

        public OrderProxy(RoutePoint routePoint, IStorageRepository<OrderItem> orderItemRepository)
            : base(routePoint) {
            _orderItemRepository = orderItemRepository;
        }

        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public int RoutePointId
        {
            get { return base.RoutePointId; }
            set { base.RoutePointId = value; }
        }

        new public DateTime OrderDate
        {
            get { return base.OrderDate; }
            set { base.OrderDate = value; }
        }

        new public DateTime ShippingDate
        {
            get { return base.ShippingDate; }
            set { base.ShippingDate = value; }
        }

        new public int CustomerId
        {
            get { return base.CustomerId; }
            set { base.CustomerId = value; }
        }

        new public string CustomerName
        {
            get { return base.CustomerName; }
            set { base.CustomerName = value; }
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

        new public int PriceListId
        {
            get { return base.PriceListId; }
            set { base.PriceListId = value; }
        }

        new public string PriceListName
        {
            get { return base.PriceListName; }
            set { base.PriceListName = value; }
        }

        new public int WarehouseId
        {
            get { return base.WarehouseId; }
            set { base.WarehouseId = value; }
        }

        new public string WarehouseAddress
        {
            get { return base.WarehouseAddress; }
            set { base.WarehouseAddress = value; }
        }

        public new decimal Amount {
            get { return base.Amount; }
            set { base.Amount = value; }
        }

        new public OrderStatus OrderStatus
        {
            get { return base.OrderStatus; }
            set { base.OrderStatus = value; }
        }

        public override IQueryObject<OrderItem> Items {
            get {
                var orderItemsSpec = new OrdersItemsSpec(this);
                return _orderItemRepository.Find().Where(orderItemsSpec);
            }
        }

        public override OrderItem CreateItem() {
            return new OrderItemProxy(this);
        }
    }
}