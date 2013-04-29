using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class RouteTemplateQueryObject : QueryObject<RouteTemplate>
    {
        public RouteTemplateQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<RouteTemplate, IDataReader> translator)
            : base(connectionFactory, translator)
        {
        }

        private const string SelectQuery = "SELECT Id, DayOfWeek FROM RouteTemplates";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
