using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
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
