namespace MSS.WinMobile.Domain.Models
{
    public partial class OrderItem
    {
        public OrderItem(Order order, Product product)
        {
            OrderId = order.Id;
            Product = product;
        }

        public int OrderId { get; private set; }

        public Product Product { get; private set; }

        public int Quantity { get; set; }
    }
}
