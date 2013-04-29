using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class CategoryDataRecordTranslator : DataRecordTranslator<Category>
    {
        protected override Category TranslateOne(IDataRecord value)
        {
            var proxy = new CategoryProxy
                {
                    Id = (value.GetInt32(value.GetOrdinal("Id"))),
                    Name = (value.GetString(value.GetOrdinal("Name"))),
                    ParentId = (value.GetInt32(value.GetOrdinal("Parent_Id")))
                };

            return proxy;
        }
    }
}
