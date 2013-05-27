using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class ProductsUnitOfMeasureDataRecordTranslator : DataRecordTranslator<ProductsUnitOfMeasure>
    {
        protected override ProductsUnitOfMeasure TranslateOne(IDataRecord value) {
            var proxy = new ProductsUnitOfMeasureProxy {
                Id = value.GetInt32(value.GetOrdinal("Id")),
                ProductId = value.GetInt32(value.GetOrdinal("Product_Id")),
                UnitOfMeasureId = value.GetInt32(value.GetOrdinal("UnitOfMeasure_Id")),
                Base = value.GetBoolean(value.GetOrdinal("Base")),
                UnitOfMeasureName = value.GetString(value.GetOrdinal("UnitOfMeasure_Name")),
                CountInBaseUnit = value.GetFloat(value.GetOrdinal("Count_In_Base_Unit"))
            };
            return proxy;
        }
    }
}
