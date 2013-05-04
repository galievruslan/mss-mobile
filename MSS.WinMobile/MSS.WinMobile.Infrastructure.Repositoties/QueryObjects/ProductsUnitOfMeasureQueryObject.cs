using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class ProductsUnitOfMeasureQueryObject : QueryObject<ProductsUnitOfMeasure>
    {
        public ProductsUnitOfMeasureQueryObject(IStorage storage,
                                                ISpecificationTranslator<ProductsUnitOfMeasure> specificationTranslator,
                                                DataRecordTranslator<ProductsUnitOfMeasure> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, Product_Id, UnitOfMeasure_Id, Base FROM ProductsUnitOfMeasures";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
