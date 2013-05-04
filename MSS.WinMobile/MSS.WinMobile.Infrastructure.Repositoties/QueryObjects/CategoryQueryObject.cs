using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class CategoryQueryObject : QueryObject<Category>
    {
        public CategoryQueryObject(IStorage storage,
                                   ISpecificationTranslator<Category> specificationTranslator,
                                   DataRecordTranslator<Category> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, Name, Parent_Id FROM Categories";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
