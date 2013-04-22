using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class CustomerQueryObject : QueryObject<Customer>
    {
        public CustomerQueryObject(SqliteConnectionFactory connectionFactory, ITranslator<Customer> translator)
            : base(connectionFactory, translator)
        {
        }

        public CustomerQueryObject(IQueryObject<Customer, string, SQLiteConnection> queryObject)
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
