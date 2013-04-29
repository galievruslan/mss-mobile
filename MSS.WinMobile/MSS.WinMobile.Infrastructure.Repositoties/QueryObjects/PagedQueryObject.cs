using System.Data;
using System.Data.SQLite;
using System.Text;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class PagedQueryObject<T> : OrderedQueryObject<T> where T : IModel
    {
        public int CountToSkip { get; protected set; }
        public int CountToTake { get; protected set; }

        public PagedQueryObject(IQueryObject<T, string, SQLiteConnection, IDataReader> queryObject, string orderByField, OrderDirection orderDirection, int countToSkip, int countToTake)
            :base(queryObject, orderByField, orderDirection)
        {
            CountToSkip = countToSkip;
            CountToTake = countToTake;
        }

        public override string AsQuery()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append(string.Format("{0} LIMIT {1} OFFSET {2}", InnerQueryObject.AsQuery(), CountToTake, CountToSkip));
            return queryStringBuilder.ToString();
        }
    }
}
