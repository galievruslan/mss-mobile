using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class RouteTemplateQueryObject : QueryObject<RouteTemplate>
    {
        public RouteTemplateQueryObject(SQLiteConnectionFactory connectionFactory, ITranslator<RouteTemplate> translator)
            : base(connectionFactory, translator)
        {
        }

        public RouteTemplateQueryObject(IQueryObject<RouteTemplate, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, DayOfWeek FROM RouteTemplates";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
