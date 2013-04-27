namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/manager_shipping_addresses.json")]
    public class MyShippingAddressDto : Dto
    {
        public int CustomerId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }
    }
}
