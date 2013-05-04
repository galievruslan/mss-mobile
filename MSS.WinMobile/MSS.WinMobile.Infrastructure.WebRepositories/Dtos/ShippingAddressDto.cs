namespace MSS.WinMobile.Infrastructure.Web.Repositories.Dtos
{
    [Url("synchronization/shipping_addresses.json")]
    public class ShippingAddressDto : Dto
    {
        public int CustomerId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }
    }
}
