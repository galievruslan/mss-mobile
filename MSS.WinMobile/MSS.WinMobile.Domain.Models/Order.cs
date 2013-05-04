using System;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class Order : Model
    {
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

        public OrderStatus OrderStatus { get; protected set; }
        public string Note { get; set; }

        public abstract IQueryObject<OrderItem> Items { get; }
    }

    public enum OrderStatus
    {
        New = 0,
        Sended = 1
    }
}
