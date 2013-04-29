using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class OrderDataRecordTranslator : DataRecordTranslator<Order>
    {
        protected override Order TranslateOne(IDataRecord value)
        {
            var proxy = new OrderProxy();
            proxy.Id = value.GetInt32(value.GetOrdinal("Id"));
            proxy.RoutePointId = value.GetInt32(value.GetOrdinal("RoutePoint_Id"));
            proxy.OrderDate = value.GetDateTime(value.GetOrdinal("OrderDate"));
            proxy.ShippingDate = value.GetDateTime(value.GetOrdinal("ShippingDate"));
            proxy.CustomerId = value.GetInt32(value.GetOrdinal("Customer_Id"));
            proxy.CustomerName = value.GetString(value.GetOrdinal("Customer_Name"));
            proxy.ShippingAddressId = value.GetInt32(value.GetOrdinal("ShippingAddress_Id"));
            proxy.ShippingAddressName = value.GetString(value.GetOrdinal("ShippingAddress_Name"));
            proxy.PriceListId = value.GetInt32(value.GetOrdinal("PriceList_Id"));
            proxy.PriceListName = value.GetString(value.GetOrdinal("PriceList_Name"));
            proxy.WarehouseId = value.GetInt32(value.GetOrdinal("Warehouse_Id"));
            proxy.WarehouseAddress = value.GetString(value.GetOrdinal("Warehouse_Address"));
            proxy.OrderStatus = (OrderStatus)value.GetInt32(value.GetOrdinal("OrderStatus"));
            proxy.Note = value.GetString(value.GetOrdinal("Note"));
            return proxy;
        }
    }
}
