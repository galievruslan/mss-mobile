using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class RouteQueryObject : QueryObject<Route>
    {
        public RouteQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<Route> translator)
            : base(connectionFactory, translator)
        {
        }

        public RouteQueryObject(IQueryObject<Route, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, [Date] FROM Routes";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
