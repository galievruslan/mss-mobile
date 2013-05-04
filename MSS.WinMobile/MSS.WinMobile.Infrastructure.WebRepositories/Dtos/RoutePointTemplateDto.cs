namespace MSS.WinMobile.Infrastructure.Web.Repositories.Dtos
{
    [Url("synchronization/template_route_points.json")]
    public class RoutePointTemplateDto : Dto
    {
        public int TemplateRouteId { get; set; }

        public int ShippingAddressId { get; set; }
    }
}
