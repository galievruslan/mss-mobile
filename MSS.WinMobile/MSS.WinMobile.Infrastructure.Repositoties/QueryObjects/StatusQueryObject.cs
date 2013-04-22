using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class StatusQueryObject : QueryObject<Status>
    {
        public StatusQueryObject(SqliteConnectionFactory connectionFactory, ITranslator<Status> translator)
            : base(connectionFactory, translator)
        {
        }

        public StatusQueryObject(IQueryObject<Status, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Name FROM Statuses";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
