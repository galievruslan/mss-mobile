using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class OrderItemProxy : OrderItem
    {
        public OrderItemProxy() {}

        public OrderItemProxy(Order order) : base(order) {}

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

        new public int UnitOfMeasureId {
            get { return base.UnitOfMeasureId; }
            set { base.UnitOfMeasureId = value; }
        }

        new public string UnitOfMeasureName {
            get { return base.UnitOfMeasureName; }
            set { base.UnitOfMeasureName = value; }
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

        new public decimal Amount {
            get { return base.Amount; }
            set { base.Amount = value; }
        }
    }
}