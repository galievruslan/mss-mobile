using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ProductsUnitOfMeasureTranslator : Translator<ProductsUnitOfMeasure>
    {
        protected override ProductsUnitOfMeasure DataRecordToModel(IDataRecord value)
        {
            var proxy = new ProductsUnitOfMeasureProxy();
            proxy.SetId(value.GetInt32(value.GetOrdinal("Id")));
            proxy.SetProductId(value.GetInt32(value.GetOrdinal("Product_Id")));
            proxy.SetUnitOfMeasureId(value.GetInt32(value.GetOrdinal("UnitOfMeasure_Id")));
            proxy.SetBase(value.GetBoolean(value.GetOrdinal("Base")));
            return proxy;
        }
    }
}
