using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class CategoryRepository : Repository<Category>
    {   
        protected override QueryObject<Category> GetQueryObject()
        {
            return new CategoryQueryObject(new CategoryTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Categories (Id, Name, Parent_Id) VALUES ({0}, '{1}', {2})";
        protected override string GetSaveQueryFor(Category model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"), model.ParentId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM Categories WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Category model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
