using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class OrderTranslator : Translator<Order>
    {
        protected override Order DataRecordToModel(IDataRecord value)
        {
            var order = new Order(value.GetInt32(value.GetOrdinal("Id")),
                value.GetDateTime(value.GetOrdinal("OrderDate")),
                value.GetDateTime(value.GetOrdinal("ShippingDate")),
                value.GetInt32(value.GetOrdinal("Customer_Id")),
                value.GetString(value.GetOrdinal("Customer_Name")),
                value.GetInt32(value.GetOrdinal("ShippingAddress_Id")),
                value.GetString(value.GetOrdinal("ShippingAddress_Name")),
                value.GetInt32(value.GetOrdinal("Manager_Id")),
                value.GetString(value.GetOrdinal("Manager_Name")),
                value.GetInt32(value.GetOrdinal("PriceList_Id")),
                value.GetString(value.GetOrdinal("PriceList_Name")),
                value.GetInt32(value.GetOrdinal("Warehouse_Id")),
                value.GetString(value.GetOrdinal("Warehouse_Address")),
                value.GetInt32(value.GetOrdinal("OrderStatus")),
                value.GetString(value.GetOrdinal("Name")));
            return order;
        }
    }
}
