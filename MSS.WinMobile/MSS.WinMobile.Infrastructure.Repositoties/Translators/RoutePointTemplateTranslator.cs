using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class RoutePointTemplateTranslator : Translator<RoutePointTemplate>
    {
        protected override RoutePointTemplate DataRecordToModel(IDataRecord value)
        {
            var proxy = new RoutePointTemplateProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    RouteTemplateId = value.GetInt32(value.GetOrdinal("RouteTemplate_Id")),
                    ShippingAddressId = value.GetInt32(value.GetOrdinal("ShippingAddress_Id"))
                };
            return proxy;
        }
    }
}
