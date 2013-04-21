using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class CategoryQueryObject : QueryObject<Category>
    {
        public CategoryQueryObject(ITranslator<Category> translator) : base(translator)
        {
        }

        public CategoryQueryObject(IQueryObject<Category, string> queryObject) : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Name, Parent_Id FROM Categories";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
