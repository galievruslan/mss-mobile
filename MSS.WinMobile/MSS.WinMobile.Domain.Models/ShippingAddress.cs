namespace MSS.WinMobile.Domain.Models
{
    public class ShippingAddress : Model
    {
        public ShippingAddress(int id, int customerId, string name, string address)
            :base(id)
        {
            CustomerId = customerId;
            Name = name;
            Address = address;
        }

        public string Address { get; private set; }

        public string Name { get; private set; }

        public int CustomerId { get; private set; }
    }
}
