namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/route_points.json")]
    public class RoutePointDto : Dto
    {
        public int ShippingAddressId { get; set; }

        public int StatusId { get; set; }
    }
}
