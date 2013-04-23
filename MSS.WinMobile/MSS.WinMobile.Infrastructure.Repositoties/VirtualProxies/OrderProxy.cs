using System;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class OrderProxy : Order
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetRoutePointId(int routePointId)
        {
            RoutePointId = routePointId;
        }

        internal void SetOrderDate(DateTime orderDate)
        {
            OrderDate = orderDate;
        }

        internal void SetShippingDate(DateTime shippingDate)
        {
            ShippingDate = shippingDate;
        }

        internal void SetCustomerId(int customerId)
        {
            CustomerId = customerId;
        }

        internal void SetCustomerName(string customerName)
        {
            CustomerName = customerName;
        }

        internal void SetShippingAddressId(int shippingAddressId)
        {
            ShippingAddressId = shippingAddressId;
        }

        internal void SetShippingAddressName(string shippingAddressName)
        {
            ShippingAddressName = shippingAddressName;
        }

        internal void SetPriceListId(int priceListId)
        {
            PriceListId = priceListId;
        }

        internal void SetPriceListName(string priceListName)
        {
            PriceListName = priceListName;
        }

        internal void SetWarehouseId(int warehouseId)
        {
            WarehouseId = warehouseId;
        }

        internal void SetWarehouseAddress(string warehouseAddress)
        {
            WarehouseAddress = warehouseAddress;
        }

        internal void SetOrderStatus(OrderStatus orderStatus)
        {
            OrderStatus = orderStatus;
        }
    }
}