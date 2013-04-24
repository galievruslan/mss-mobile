using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class RouteTranslator : Translator<Route>
    {
        protected override Route DataRecordToModel(IDataRecord value)
        {
            var proxy = new RouteProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Date = value.GetDateTime(value.GetOrdinal("Date"))
                };
            return proxy;
        }
    }
}
