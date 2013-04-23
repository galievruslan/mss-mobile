using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ProductsPriceTranslator : Translator<ProductsPrice>
    {
        protected override ProductsPrice DataRecordToModel(IDataRecord value)
        {
            var proxy = new ProductsPriceProxy();
            proxy.SetId(value.GetInt32(value.GetOrdinal("Id")));
            proxy.SetProductId(value.GetInt32(value.GetOrdinal("Product_Id")));
            proxy.SetProductName(value.GetString(value.GetOrdinal("Product_Name")));
            proxy.SetPriceListId(value.GetInt32(value.GetOrdinal("PriceList_Id")));
            proxy.SetPrice(value.GetDecimal(value.GetOrdinal("Price")));
            return proxy;
        }
    }
}
