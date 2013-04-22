using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class UnitOfMeasureQueryObject : QueryObject<UnitOfMeasure>
    {
        public UnitOfMeasureQueryObject(SQLiteConnectionFactory connectionFactory, ITranslator<UnitOfMeasure> translator)
            : base(connectionFactory, translator)
        {
        }

        public UnitOfMeasureQueryObject(IQueryObject<UnitOfMeasure, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Name FROM UnitsOfMeasure";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
