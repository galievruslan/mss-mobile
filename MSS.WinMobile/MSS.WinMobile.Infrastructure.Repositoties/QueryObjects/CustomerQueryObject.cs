using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class CustomerQueryObject : QueryObject<Customer>
    {
        public CustomerQueryObject(ITranslator<Customer> translator)
            : base(translator)
        {
        }

        public CustomerQueryObject(IQueryObject<Customer, string> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Name FROM Customers";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
