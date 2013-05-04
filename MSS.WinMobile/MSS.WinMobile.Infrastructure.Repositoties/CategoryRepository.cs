using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class CategoryStorageRepository : SqLiteStorageRepository<Category> {
        private readonly ISpecificationTranslator<Category> _specificationTranslator;
        internal CategoryStorageRepository(IStorage storage, ISpecificationTranslator<Category> specificationTranslator)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
        }

        protected override QueryObject<Category> GetQueryObject()
        {
            return new CategoryQueryObject(Storage, _specificationTranslator, new CategoryDataRecordTranslator());
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
