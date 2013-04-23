using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class OrderItemProxy : OrderItem
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetOrderId(int orderId)
        {
            OrderId = orderId;
        }

        internal void SetProductId(int productId)
        {
            ProductId = productId;
        }

        internal void SetProductName(string productName)
        {
            ProductName = productName;
        }
    }
}