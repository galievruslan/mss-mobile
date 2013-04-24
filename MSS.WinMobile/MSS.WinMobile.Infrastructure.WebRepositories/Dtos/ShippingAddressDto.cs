namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    public class ShippingAddressDto : Dto
    {
        public int CustomerId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }
    }
}
