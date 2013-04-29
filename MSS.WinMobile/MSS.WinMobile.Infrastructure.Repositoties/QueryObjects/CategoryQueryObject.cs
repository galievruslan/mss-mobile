using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class CategoryQueryObject : QueryObject<Category>
    {
        public CategoryQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<Category, IDataReader> translator)
            : base(connectionFactory, translator)
        {
        }

        private const string SelectQuery = "SELECT Id, Name, Parent_Id FROM Categories";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
