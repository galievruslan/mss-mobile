using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class CategoryTranslator : Translator<Category>
    {
        protected override Category DataRecordToModel(IDataRecord value)
        {
            var category = new Category(value.GetInt32(value.GetOrdinal("Id")),
                value.GetString(value.GetOrdinal("Name")),
                value.GetInt32(value.GetOrdinal("Parent_Id")));
            return category;
        }
    }
}
