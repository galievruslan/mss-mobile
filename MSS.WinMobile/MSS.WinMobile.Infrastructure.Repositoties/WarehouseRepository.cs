using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class WarehouseStorageRepository : SqLiteStorageRepository<Warehouse> {
        private readonly ISpecificationTranslator<Warehouse> _specificationTranslator;
        internal WarehouseStorageRepository(IStorage storage, ISpecificationTranslator<Warehouse> specificationTranslator)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
        }

        protected override QueryObject<Warehouse> GetQueryObject()
        {
            return new WarehouseQueryObject(Storage, _specificationTranslator, new WarehouseDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Warehouses (Id, Name, Address) VALUES ({0}, '{1}', '{2}')";
        protected override string GetSaveQueryFor(Warehouse model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"), model.Address.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM Warehouses WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Warehouse model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
