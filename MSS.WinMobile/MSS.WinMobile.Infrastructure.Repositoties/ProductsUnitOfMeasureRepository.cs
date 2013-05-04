using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class ProductsUnitOfMeasureStorageRepository : SqLiteStorageRepository<ProductsUnitOfMeasure> {
        private readonly ISpecificationTranslator<ProductsUnitOfMeasure> _specificationTranslator;
        internal ProductsUnitOfMeasureStorageRepository(IStorage storage, ISpecificationTranslator<ProductsUnitOfMeasure> specificationTranslator)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
        }

        protected override QueryObject<ProductsUnitOfMeasure> GetQueryObject()
        {
            return new ProductsUnitOfMeasureQueryObject(Storage, _specificationTranslator, new ProductsUnitOfMeasureDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO ProductsUnitOfMeasures (Id, Product_Id, UnitOfMeasure_Id, Base) VALUES ({0}, {1}, {2}, {3})";
        protected override string GetSaveQueryFor(ProductsUnitOfMeasure model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.ProductId, model.UnitOfMeasureId, model.Base ? 1 : 0);
        }

        private const string DeleteQueryTemplate = "DELETE FROM ProductsUnitOfMeasures WHERE Id = {0}";
        protected override string GetDeleteQueryFor(ProductsUnitOfMeasure model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
