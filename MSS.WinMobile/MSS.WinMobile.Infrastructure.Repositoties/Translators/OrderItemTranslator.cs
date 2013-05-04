using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class OrderItemDataRecordTranslator : DataRecordTranslator<OrderItem>
    {
        protected override OrderItem TranslateOne(IDataRecord value)
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
