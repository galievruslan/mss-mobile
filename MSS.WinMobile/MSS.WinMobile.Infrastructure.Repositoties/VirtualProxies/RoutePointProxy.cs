using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class RoutePointProxy : RoutePoint
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetRouteId(int routeId)
        {
            RouteId = routeId;
        }

        internal void SetShippingAddressId(int shippingAddressId)
        {
            ShippingAddressId = shippingAddressId;
        }

        internal void SetShippingAddressName(string shippingAddressName)
        {
            ShippingAddressName = shippingAddressName;
        }

        internal void SetStatusId(int statusId)
        {
            StatusId = statusId;
        }
    }
}