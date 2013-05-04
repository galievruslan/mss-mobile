using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class CustomerQueryObject : QueryObject<Customer>
    {
        public CustomerQueryObject(IStorage storage,
                                   ISpecificationTranslator<Customer> specificationTranslator,
                                   DataRecordTranslator<Customer> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, Name FROM Customers";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
