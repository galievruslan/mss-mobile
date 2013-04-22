using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class OrderItemTranslator : Translator<OrderItem>
    {
        protected override OrderItem DataRecordToModel(IDataRecord value)
        {
            var orderItem = new OrderItem(value.GetInt32(value.GetOrdinal("Id")),
                value.GetInt32(value.GetOrdinal("Order_Id")),
                value.GetInt32(value.GetOrdinal("Product_Id")),
                value.GetString(value.GetOrdinal("Product_Name")),
                value.GetInt32(value.GetOrdinal("Quantity")));
            return orderItem;
        }
    }
}
