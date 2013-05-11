namespace MSS.WinMobile.Domain.Models
{
    public class OrderItem : Model
    {
        public int OrderId { get; protected set; }

        public int ProductId { get; protected set; }
        public string ProductName { get; protected set; }

        public int Quantity { get; set; }

        public decimal Price { get; protected set; }
    }
}
