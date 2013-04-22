using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ProductsPriceTranslator : Translator<ProductsPrice>
    {
        protected override ProductsPrice DataRecordToModel(IDataRecord value)
        {
            var productsPrice = new ProductsPrice(value.GetInt32(value.GetOrdinal("Id")),
                value.GetInt32(value.GetOrdinal("Product_Id")),
                value.GetString(value.GetOrdinal("Product_Name")),
                value.GetInt32(value.GetOrdinal("PriceList_Id")),
                value.GetDecimal(value.GetOrdinal("Price")));
            return productsPrice;
        }
    }
}
