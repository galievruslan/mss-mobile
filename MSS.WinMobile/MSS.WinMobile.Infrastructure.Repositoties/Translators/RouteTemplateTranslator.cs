using System;
using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class RouteTemplateDataRecordTranslator : DataRecordTranslator<RouteTemplate>
    {
        protected override RouteTemplate TranslateOne(IDataRecord value)
        {
            var proxy = new RouteTemplateProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    DayOfWeek = (DayOfWeek) value.GetInt32(value.GetOrdinal("DayOfWeek"))
                };
            return proxy;
        }
    }
}
