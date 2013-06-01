using System;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class Order : Model
    {
        protected Order() {
            GUID = Guid.NewGuid();
        }

        protected Order(RoutePoint routePoint) : this() {
            RoutePointId = routePoint.Id;
        }

        public int RoutePointId { get; protected set; }

        public DateTime OrderDate { get; protected set; }
        public DateTime ShippingDate { get; protected set; }

        public int CustomerId { get; protected set; }
        public string CustomerName { get; protected set; }

        public int ShippingAddressId { get; protected set; }
        public string ShippingAddressName { get; protected set; }

        public int PriceListId { get; protected set; }
        public string PriceListName { get; protected set; }

        public int WarehouseId { get; protected set; }
        public string WarehouseName { get; protected set; }

        public decimal Amount { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public string Note { get; set; }

        public bool Synchronized { get; set; }

        public Guid GUID { get; set; }

        public abstract IQueryObject<OrderItem> Items { get; }

        public void SetOrderDate(DateTime orderDate) {
            OrderDate = orderDate;
        }

        public void SetShippingDate(DateTime shippingDate) {
            ShippingDate = shippingDate;
        }

        public void SetCustomer(Customer customer) {
            CustomerId = customer.Id;
            CustomerName = customer.Name;
        }

        public void SetShippingAddress(ShippingAddress shippingAddress) {
            ShippingAddressId = shippingAddress.Id;
            ShippingAddressName = shippingAddress.Name;
        }

        public void SetPriceList(PriceList priceList) {
            PriceListId = priceList.Id;
            PriceListName = priceList.Name;
        }

        public void SetWarehouse(Warehouse warehouse) {
            WarehouseId = warehouse.Id;
            WarehouseName = warehouse.Address;
        }

        public abstract OrderItem CreateItem();
    }

    public enum OrderStatus
    {
        New = 0,
        Sended = 1
    }
}
