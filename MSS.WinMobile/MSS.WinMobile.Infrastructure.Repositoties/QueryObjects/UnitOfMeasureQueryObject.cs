using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class UnitOfMeasureQueryObject : QueryObject<UnitOfMeasure>
    {
        public UnitOfMeasureQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<UnitOfMeasure, IDataReader> translator)
            : base(connectionFactory, translator)
        {
        }

        private const string SelectQuery = "SELECT Id, Name FROM UnitsOfMeasure";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
