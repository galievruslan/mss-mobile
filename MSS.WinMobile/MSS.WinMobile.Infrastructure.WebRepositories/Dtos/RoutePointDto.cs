namespace MSS.WinMobile.Infrastructure.Web.Repositories.Dtos
{
    [Url("synchronization/route_points.json")]
    public class RoutePointDto : Dto
    {
        public int ShippingAddressId { get; set; }

        public int StatusId { get; set; }
    }
}
