using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class RoutePointDataRecordTranslator : DataRecordTranslator<RoutePoint>
    {
        protected override RoutePoint TranslateOne(IDataRecord value)
        {
            var proxy = new RoutePointProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    RouteId = value.GetInt32(value.GetOrdinal("Route_Id")),
                    ShippingAddressId = value.GetInt32(value.GetOrdinal("ShippingAddress_Id")),
                    ShippingAddressName = value.GetString(value.GetOrdinal("ShippingAddress_Name")),
                    StatusId = value.GetInt32(value.GetOrdinal("Status_Id"))
                };
            return proxy;
        }
    }
}
