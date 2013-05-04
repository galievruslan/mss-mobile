using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class CustomerStorageRepository : SqLiteStorageRepository<Customer> {

        private readonly ISpecificationTranslator<Customer> _customersSpecTranslator;
        private readonly IRepositoryFactory _repositoryFactory;
        internal CustomerStorageRepository(IStorage storage,
            ISpecificationTranslator<Customer> customersSpecTranslator, IRepositoryFactory repositoryFactory)
            : base(storage) {
            _customersSpecTranslator = customersSpecTranslator;
            _repositoryFactory = repositoryFactory;
        }

        protected override QueryObject<Customer> GetQueryObject() {
            return new CustomerQueryObject(Storage, _customersSpecTranslator,
                                           new CustomerTranslator(_repositoryFactory));
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Customers (Id, Name) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(Customer model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM Customers WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Customer model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
