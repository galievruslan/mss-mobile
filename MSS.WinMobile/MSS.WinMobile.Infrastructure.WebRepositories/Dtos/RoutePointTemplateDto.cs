namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/template_route_points.json")]
    public class RoutePointTemplateDto : Dto
    {
        public int RouteTemplateId { get; set; }

        public int ShippingAddressId { get; set; }
    }
}
