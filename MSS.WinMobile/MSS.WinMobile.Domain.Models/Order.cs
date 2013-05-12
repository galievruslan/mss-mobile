using System;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class Order : Model
    {
        protected Order() {}

        protected Order(RoutePoint routePoint) {
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
        public string WarehouseAddress { get; protected set; }

        public OrderStatus OrderStatus { get; set; }
        public string Note { get; set; }

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
            WarehouseAddress = warehouse.Address;
        }

        public abstract OrderItem CreateItem();
    }

    public enum OrderStatus
    {
        New = 0,
        Sended = 1
    }
}
