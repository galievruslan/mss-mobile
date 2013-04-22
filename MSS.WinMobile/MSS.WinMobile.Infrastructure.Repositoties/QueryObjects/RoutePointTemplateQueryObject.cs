using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class RoutePointTemplateQueryObject : QueryObject<RoutePointTemplate>
    {
        public RoutePointTemplateQueryObject(SqliteConnectionFactory connectionFactory, ITranslator<RoutePointTemplate> translator)
            : base(connectionFactory, translator)
        {
        }

        public RoutePointTemplateQueryObject(IQueryObject<RoutePointTemplate, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, RouteTemplate_Id, ShippingAddress_Id FROM RoutePointTemplates";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
