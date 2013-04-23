namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    public class CustomerDto : Dto
    {
        public CustomerDto()
        {
            ShippingAddresses = new ShippingAddressDto[0];
        }

        public string Name { get; set; }

        public ShippingAddressDto[] ShippingAddresses { get; set; }
    }
}
