using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class OrderedQueryObject<T> : QueryObject<T> where T : ActiveRecordBase
    {
        public string OrderByField { get; protected set; }
        public OrderDirection OrderDirection { get; protected set; }

        public OrderedQueryObject(QueryObject<T> queryObject, string orderByField, OrderDirection orderDirection)
            :base(queryObject)
        {
            OrderByField = orderByField;
            OrderDirection = orderDirection;
        }

        public override string ToString()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append(string.Format("{0} ORDER BY [{1}].[{2}] ", InnerQuery, TableName, OrderByField));
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
