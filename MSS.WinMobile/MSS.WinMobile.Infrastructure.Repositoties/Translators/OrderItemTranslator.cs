using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class OrderItemTranslator : Translator<OrderItem>
    {
        protected override OrderItem DataRecordToModel(IDataRecord value)
        {
            var proxy = new OrderItemProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    OrderId = value.GetInt32(value.GetOrdinal("Order_Id")),
                    ProductId = value.GetInt32(value.GetOrdinal("Product_Id")),
                    ProductName = value.GetString(value.GetOrdinal("Product_Name")),
                    Quantity = value.GetInt32(value.GetOrdinal("Quantity"))
                };
            return proxy;
        }
    }
}
