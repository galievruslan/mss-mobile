using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class RoutePointTemplateProxy : RoutePointTemplate
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetRouteTemplateId(int routeTemplateId)
        {
            RouteTemplateId = routeTemplateId;
        }

        internal void SetShippingAddressId(int shippingAddressId)
        {
            ShippingAddressId = shippingAddressId;
        }
    }
}