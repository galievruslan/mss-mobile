using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class OrderTranslator : Translator<Order>
    {
        protected override Order DataRecordToModel(IDataRecord value)
        {
            var proxy = new OrderProxy();
            proxy.SetId(value.GetInt32(value.GetOrdinal("Id")));
            proxy.SetRoutePointId(value.GetInt32(value.GetOrdinal("RoutePoint_Id")));
            proxy.SetOrderDate(value.GetDateTime(value.GetOrdinal("OrderDate")));
            proxy.SetShippingDate(value.GetDateTime(value.GetOrdinal("ShippingDate")));
            proxy.SetCustomerId(value.GetInt32(value.GetOrdinal("Customer_Id")));
            proxy.SetCustomerName(value.GetString(value.GetOrdinal("Customer_Name")));
            proxy.SetShippingAddressId(value.GetInt32(value.GetOrdinal("ShippingAddress_Id")));
            proxy.SetShippingAddressName(value.GetString(value.GetOrdinal("ShippingAddress_Name")));
            proxy.SetPriceListId(value.GetInt32(value.GetOrdinal("PriceList_Id")));
            proxy.SetPriceListName(value.GetString(value.GetOrdinal("PriceList_Name")));
            proxy.SetWarehouseId(value.GetInt32(value.GetOrdinal("Warehouse_Id")));
            proxy.SetWarehouseAddress(value.GetString(value.GetOrdinal("Warehouse_Address")));
            proxy.SetOrderStatus((OrderStatus)value.GetInt32(value.GetOrdinal("OrderStatus")));
            proxy.Note = value.GetString(value.GetOrdinal("Note"));
            return proxy;
        }
    }
}
