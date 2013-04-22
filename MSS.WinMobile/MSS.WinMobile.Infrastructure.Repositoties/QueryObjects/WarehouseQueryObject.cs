using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class WarehouseQueryObject : QueryObject<Warehouse>
    {
        public WarehouseQueryObject(SQLiteConnectionFactory connectionFactory, ITranslator<Warehouse> translator)
            : base(connectionFactory, translator)
        {
        }

        public WarehouseQueryObject(IQueryObject<Warehouse, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Address FROM Warehouses";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
