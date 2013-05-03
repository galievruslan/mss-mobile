namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/template_route_points.json")]
    public class RoutePointTemplateDto : Dto
    {
        public int TemplateRouteId { get; set; }

        public int ShippingAddressId { get; set; }
    }
}
