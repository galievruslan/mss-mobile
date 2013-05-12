using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class ProductStorageRepository : SqLiteStorageRepository<Product> {
        private readonly ISpecificationTranslator<Product> _specificationTranslator;
        private readonly IRepositoryFactory _repositoryFactory;
        internal ProductStorageRepository(IStorage storage, ISpecificationTranslator<Product> specificationTranslator, IRepositoryFactory repositoryFactory)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
            _repositoryFactory = repositoryFactory;
        }

        protected override QueryObject<Product> GetQueryObject()
        {
            return new ProductQueryObject(Storage, _specificationTranslator, new ProductDataRecordTranslator(_repositoryFactory));
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Products (Id, Name, Category_Id) VALUES ({0}, '{1}', {2})";
        protected override string GetSaveQueryFor(Product model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"), model.CategoryId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM Products WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Product model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
