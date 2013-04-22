using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class RouteTranslator : Translator<Route>
    {
        protected override Route DataRecordToModel(IDataRecord value)
        {
            var route = new Route(value.GetInt32(value.GetOrdinal("Id")),
                value.GetInt32(value.GetOrdinal("Manager_Id")),
                value.GetDateTime(value.GetOrdinal("Date")));
            return route;
        }
    }
}
