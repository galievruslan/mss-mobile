using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ProductsUnitOfMeasureTranslator : Translator<ProductsUnitOfMeasure>
    {
        protected override ProductsUnitOfMeasure DataRecordToModel(IDataRecord value)
        {
            var productsUnitOfMeasure = new ProductsUnitOfMeasure(value.GetInt32(value.GetOrdinal("Id")),
                value.GetInt32(value.GetOrdinal("Product_Id")),
                value.GetInt32(value.GetOrdinal("UnitOfMeasure_Id")),
                value.GetBoolean(value.GetOrdinal("Base")));
            return productsUnitOfMeasure;
        }
    }
}
