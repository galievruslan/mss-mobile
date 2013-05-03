using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public class RoutePointTemplateTranslator : DtoTranslator<RoutePointTemplate, RoutePointTemplateDto>
    {
        public override RoutePointTemplate Translate(RoutePointTemplateDto value)
        {
            var proxy = new RoutePointTemplateProxy
                {
                    Id = value.Id,
                    RouteTemplateId = value.TemplateRouteId,
                    ShippingAddressId = value.ShippingAddressId
                };
            return proxy;
        }
    }
}
