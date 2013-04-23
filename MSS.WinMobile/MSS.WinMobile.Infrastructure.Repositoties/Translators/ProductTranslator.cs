using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ProductTranslator : Translator<Product>
    {
        protected override Product DataRecordToModel(IDataRecord value)
        {
            var proxy = new ProductProxy();
            proxy.SetId(value.GetInt32(value.GetOrdinal("Id")));
            proxy.SetName(value.GetString(value.GetOrdinal("Name")));
            proxy.SetCategoryId(value.GetInt32(value.GetOrdinal("Category_Id")));
            return proxy;
        }
    }
}
