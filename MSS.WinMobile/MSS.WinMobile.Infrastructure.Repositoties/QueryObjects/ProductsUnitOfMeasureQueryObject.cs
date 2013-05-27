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

        private const string SelectQuery = "SELECT productsUoM.Id as Id, productsUoM.Product_Id as Product_Id, productsUoM.UnitOfMeasure_Id as UnitOfMeasure_Id, productsUoM.Base as [Base], productsUoM.[Count_In_Base_Unit] as [Count_In_Base_Unit], uom.Name as UnitOfMeasure_Name FROM ProductsUnitOfMeasures productsUoM" +
                                           " left join UnitsOfMeasure uom on productsUoM.UnitOfMeasure_Id = uom.Id";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
