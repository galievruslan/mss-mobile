using System;
using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class RouteTemplateTranslator : Translator<RouteTemplate>
    {
        protected override RouteTemplate DataRecordToModel(IDataRecord value)
        {
            var routeTemplate = new RouteTemplate(value.GetInt32(value.GetOrdinal("Id")),
                                                  value.GetInt32(value.GetOrdinal("Manager_Id")),
                                                  (DayOfWeek) value.GetInt32(value.GetOrdinal("DayOfWeek")));
            return routeTemplate;
        }
    }
}
