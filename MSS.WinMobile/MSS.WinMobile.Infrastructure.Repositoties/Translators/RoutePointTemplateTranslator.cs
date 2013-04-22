using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class RoutePointTemplateTranslator : Translator<RoutePointTemplate>
    {
        protected override RoutePointTemplate DataRecordToModel(IDataRecord value)
        {
            var routePointTemplate = new RoutePointTemplate(value.GetInt32(value.GetOrdinal("Id")),
                value.GetInt32(value.GetOrdinal("RouteTemplate_Id")),
                value.GetInt32(value.GetOrdinal("ShippingAddress_Id")));
            return routePointTemplate;
        }
    }
}
