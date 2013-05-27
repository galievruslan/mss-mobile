using System.Data.SQLite;
using System.Globalization;
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

        private static readonly NumberFormatInfo DecimalFormat = NumberFormatInfo.InvariantInfo;
        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO ProductsUnitOfMeasures (Id, Product_Id, UnitOfMeasure_Id, Count_In_Base_Unit, Base) VALUES ({0}, {1}, {2}, {3}, {4})";
        protected override string GetSaveQueryFor(ProductsUnitOfMeasure model) {
            return string.Format(SaveQueryTemplate, model.Id, model.ProductId, model.UnitOfMeasureId,
                                 model.CountInBaseUnit.ToString(DecimalFormat), model.Base ? 1 : 0);
        }

        private const string DeleteQueryTemplate = "DELETE FROM ProductsUnitOfMeasures WHERE Id = {0}";
        protected override string GetDeleteQueryFor(ProductsUnitOfMeasure model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
