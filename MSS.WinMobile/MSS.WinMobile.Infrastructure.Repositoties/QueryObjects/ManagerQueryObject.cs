using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class ManagerQueryObject : QueryObject<Manager>
    {
        public ManagerQueryObject(SQLiteConnectionFactory connectionFactory, ITranslator<Manager> translator)
            : base(connectionFactory, translator)
        {
        }

        public ManagerQueryObject(IQueryObject<Manager, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Name FROM Managers";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
