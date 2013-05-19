using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class WarehouseQueryObject : QueryObject<Warehouse>
    {
        public WarehouseQueryObject(IStorage storage,
                                    ISpecificationTranslator<Warehouse> specificationTranslator,
                                    DataRecordTranslator<Warehouse> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, Name, Address, [Default] FROM Warehouses";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
