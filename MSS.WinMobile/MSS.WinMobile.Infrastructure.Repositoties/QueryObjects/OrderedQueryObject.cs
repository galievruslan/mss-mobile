using System.Data;
using System.Data.SQLite;
using System.Text;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class OrderedQueryObject<T> : QueryObject<T> where T : IModel
    {
        public string OrderByField { get; protected set; }
        public OrderDirection OrderDirection { get; protected set; }

        public OrderedQueryObject(IQueryObject<T, string, SQLiteConnection, IDataReader> queryObject, string orderByField, OrderDirection orderDirection)
            :base(queryObject)
        {
            OrderByField = orderByField;
            OrderDirection = orderDirection;
        }

        public override string AsQuery()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append(string.Format("{0} ORDER BY [{1}] ", InnerQueryObject.AsQuery(), OrderByField));
            queryStringBuilder.Append(OrderDirection == OrderDirection.Asceding ? "ASC " : "DESC ");
            return queryStringBuilder.ToString();
        }
    }

    public enum OrderDirection
    {
        Asceding,
        Desceding
    }
}
