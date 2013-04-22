namespace MSS.WinMobile.Domain.Models
{
    public class OrderItem : Model
    {
        public OrderItem(int id, int orderId, int productId, string productName, int quantity)
            :base(id)
        {

            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
        }

        public int OrderId { get; private set; }

        public int ProductId { get; private set; }
        public string ProductName { get; private set; }

        public int Quantity { get; set; }
    }
}
