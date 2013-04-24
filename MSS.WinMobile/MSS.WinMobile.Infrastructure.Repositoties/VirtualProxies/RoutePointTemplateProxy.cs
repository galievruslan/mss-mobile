using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class RoutePointTemplateProxy : RoutePointTemplate
    {
        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public int RouteTemplateId
        {
            get { return base.RouteTemplateId; }
            set { base.RouteTemplateId = value; }
        }

        new public int ShippingAddressId
        {
            get { return base.ShippingAddressId; }
            set { base.ShippingAddressId = value; }
        }
    }
}