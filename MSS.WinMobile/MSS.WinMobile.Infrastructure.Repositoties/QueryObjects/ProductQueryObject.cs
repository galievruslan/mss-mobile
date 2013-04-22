using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class ProductQueryObject : QueryObject<Product>
    {
        public ProductQueryObject(SqliteConnectionFactory connectionFactory, ITranslator<Product> translator)
            : base(connectionFactory, translator)
        {
        }

        public ProductQueryObject(IQueryObject<Product, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Name, Category_Id FROM Products";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
