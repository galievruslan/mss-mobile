using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class TakeQueryObject<T> : OrderedQueryObject<T> where T : ActiveRecordBase
    {
        public int CountToTake { get; protected set; }

        public TakeQueryObject(QueryObject<T> queryObject, string orderByField, OrderDirection orderDirection, int countToTake)
            :base(queryObject, orderByField, orderDirection)
        {
            CountToTake = countToTake;
        }

        public override bool CanBeInner
        {
            get
            {
                return true;
            }
        }

        public override string ToString()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append(string.Format("SELECT TOP({0}) ", CountToTake));
            for (int i = 0; i < FieldsNames.Length; i++)
            {
                if (i > 0)
                    queryStringBuilder.Append(", ");

                queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}]", TableName, FieldsNames[i]));
            }
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [{1}]", InnerQuery, TableName));
            queryStringBuilder.Append(string.Format(" ORDER BY [{0}].[{1}] ", TableName, OrderByField));
            queryStringBuilder.Append(OrderDirection == OrderDirection.Asceding ? "ASC" : "DESC");

            return queryStringBuilder.ToString();
        }
    }
}
