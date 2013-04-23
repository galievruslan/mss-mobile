using System;
using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class RouteTemplateTranslator : Translator<RouteTemplate>
    {
        protected override RouteTemplate DataRecordToModel(IDataRecord value)
        {
            var proxy = new RouteTemplateProxy();
            proxy.SetId(value.GetInt32(value.GetOrdinal("Id")));
            proxy.SetRouteTemplateId((DayOfWeek) value.GetInt32(value.GetOrdinal("DayOfWeek")));
            return proxy;
        }
    }
}
