using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class OrderItemProxy : OrderItem
    {
        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public int OrderId
        {
            get { return base.OrderId; }
            set { base.OrderId = value; }
        }

        new public int ProductId
        {
            get { return base.ProductId; }
            set { base.ProductId = value; }
        }

        new public string ProductName
        {
            get { return base.ProductName; }
            set { base.ProductName = value; }
        }

        new public int Quantity
        {
            get { return base.Quantity; }
            set { base.Quantity = value; }
        }

        new public decimal Price
        {
            get { return base.Price; }
            set { base.Price = value; }
        }
    }
}