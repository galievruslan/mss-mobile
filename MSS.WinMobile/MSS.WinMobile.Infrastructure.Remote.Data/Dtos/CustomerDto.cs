namespace MSS.WinMobile.Infrastructure.Remote.Data.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ShippingAddressDto[] ShippingAddresses { get; set; }
    }
}
