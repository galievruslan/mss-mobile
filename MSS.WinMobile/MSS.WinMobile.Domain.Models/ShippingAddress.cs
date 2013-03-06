namespace MSS.WinMobile.Domain.Models
{
    public partial class ShippingAddress
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public int CustomerId { get; set; }
    }
}
