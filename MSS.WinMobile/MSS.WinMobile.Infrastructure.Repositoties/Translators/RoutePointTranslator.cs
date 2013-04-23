using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class RoutePointTranslator : Translator<RoutePoint>
    {
        protected override RoutePoint DataRecordToModel(IDataRecord value)
        {
            var proxy = new RoutePointProxy();
            proxy.SetId(value.GetInt32(value.GetOrdinal("Id")));
            proxy.SetRouteId(value.GetInt32(value.GetOrdinal("Route_Id")));
            proxy.SetShippingAddressId(value.GetInt32(value.GetOrdinal("ShippingAddress_Id")));
            proxy.SetShippingAddressName(value.GetString(value.GetOrdinal("ShippingAddress_Name")));
            proxy.SetStatusId(value.GetInt32(value.GetOrdinal("Status_Id")));
            return proxy;
        }
    }
}
