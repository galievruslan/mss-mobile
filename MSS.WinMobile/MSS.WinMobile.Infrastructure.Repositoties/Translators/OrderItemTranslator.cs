using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class OrderItemTranslator : Translator<OrderItem>
    {
        protected override OrderItem DataRecordToModel(IDataRecord value)
        {
            var proxy = new OrderItemProxy();
            proxy.SetId(value.GetInt32(value.GetOrdinal("Id")));
            proxy.SetOrderId(value.GetInt32(value.GetOrdinal("Order_Id")));
            proxy.SetProductId(value.GetInt32(value.GetOrdinal("Product_Id")));
            proxy.SetProductName(value.GetString(value.GetOrdinal("Product_Name")));
            proxy.Quantity = value.GetInt32(value.GetOrdinal("Quantity"));
            return proxy;
        }
    }
}
