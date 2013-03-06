namespace MSS.WinMobile.Infrastructure.Server.Dtos
{
    public class CustomerDto
    {
        public CustomerDto()
        {
            ShippingAddresses = new ShippingAddressDto[0];
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ShippingAddressDto[] ShippingAddresses { get; set; }
    }
}
