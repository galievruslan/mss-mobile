using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class WarehouseQueryObject : QueryObject<Warehouse>
    {
        public WarehouseQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<Warehouse, IDataReader> translator)
            : base(connectionFactory, translator)
        {
        }

        private const string SelectQuery = "SELECT Id, Address FROM Warehouses";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
