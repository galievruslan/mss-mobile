using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class RoutePointProxy : RoutePoint
    {
        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public int RouteId
        {
            get { return base.RouteId; }
            set { base.RouteId = value; }
        }

        new public int ShippingAddressId
        {
            get { return base.ShippingAddressId; }
            set { base.ShippingAddressId = value; }
        }

        new public string ShippingAddressName
        {
            get { return base.ShippingAddressName; }
            set { base.ShippingAddressName = value; }
        }

        new public int StatusId
        {
            get { return base.StatusId; }
            set { base.StatusId = value; }
        }
    }
}