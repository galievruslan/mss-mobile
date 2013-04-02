namespace MSS.WinMobile.Domain.Models
{
    public partial class ShippingAddress
    {
        public ShippingAddress(int id, int customerId, string name, string address)
        {
            Id = id;
            CustomerId = customerId;
            Name = name;
            Address = address;
        }

        public string Address { get; private set; }

        public string Name { get; private set; }

        public int CustomerId { get; private set; }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var shippingAddress = obj as ShippingAddress;
            if (shippingAddress != null)
            {
                return shippingAddress.Id == Id;
            }

            return false;
        }
    }
}
