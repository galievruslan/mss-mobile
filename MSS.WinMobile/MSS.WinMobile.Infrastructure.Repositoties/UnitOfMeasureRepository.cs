using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class UnitOfMeasureStorageRepository : SqLiteStorageRepository<UnitOfMeasure> {
        private readonly ISpecificationTranslator<UnitOfMeasure> _specificationTranslator;
        internal UnitOfMeasureStorageRepository(IStorage storage, ISpecificationTranslator<UnitOfMeasure> specificationTranslator)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
        }

        protected override QueryObject<UnitOfMeasure> GetQueryObject()
        {
            return new UnitOfMeasureQueryObject(Storage, _specificationTranslator, new UnitOfMeasureDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO UnitsOfMeasure (Id, Name) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(UnitOfMeasure model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM UnitsOfMeasure WHERE Id = {0}";
        protected override string GetDeleteQueryFor(UnitOfMeasure model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
