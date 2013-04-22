using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ProductTranslator : Translator<Product>
    {
        protected override Product DataRecordToModel(IDataRecord value)
        {
            var product = new Product(value.GetInt32(value.GetOrdinal("Id")),
                value.GetString(value.GetOrdinal("Name")),
                value.GetInt32(value.GetOrdinal("Category_Id")));
            return product;
        }
    }
}
