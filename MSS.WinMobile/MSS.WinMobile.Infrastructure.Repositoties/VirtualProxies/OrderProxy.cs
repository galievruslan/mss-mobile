using System;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class OrderProxy : Order
    {
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

        new public OrderStatus OrderStatus
        {
            get { return base.OrderStatus; }
            set { base.OrderStatus = value; }
        }
    }
}