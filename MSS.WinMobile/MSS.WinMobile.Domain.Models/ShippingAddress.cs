namespace MSS.WinMobile.Domain.Models
{
    public class ShippingAddress : Model
    {
        public string Address { get; protected set; }

        public string Name { get; protected set; }

        public int CustomerId { get; protected set; }
    }
}
