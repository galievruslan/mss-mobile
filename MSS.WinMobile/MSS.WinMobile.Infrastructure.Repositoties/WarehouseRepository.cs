using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class WarehouseRepository : SqLiteRepository<Warehouse>
    {
        public WarehouseRepository(SqLiteUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected override QueryObject<Warehouse> GetQueryObject()
        {
            return new WarehouseQueryObject(UnitOfWork, new WarehouseDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Warehouses (Id, Address) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(Warehouse model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Address.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM Warehouses WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Warehouse model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
