using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class StatusQueryObject : QueryObject<Status>
    {
        public StatusQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<Status, IDataReader> translator)
            : base(connectionFactory, translator)
        {
        }

        private const string SelectQuery = "SELECT Id, Name FROM Statuses";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
