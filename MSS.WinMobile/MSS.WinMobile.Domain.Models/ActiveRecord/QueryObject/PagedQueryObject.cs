using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class PagedQueryObject<T> : OrderedQueryObject<T> where T : ActiveRecordBase
    {
        public int CountToSkip { get; protected set; }
        public int CountToTake { get; protected set; }

        public PagedQueryObject(QueryObject<T> queryObject, string orderByField, OrderDirection orderDirection, int countToSkip, int countToTake)
            :base(queryObject, orderByField, orderDirection)
        {
            CountToSkip = countToSkip;
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
            queryStringBuilder.Append("SELECT ");
            for (int i = 0; i < FieldsNames.Length; i++)
            {
                if (i > 0)
                    queryStringBuilder.Append(", ");

                queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}]", TableName, FieldsNames[i]));
            }
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [{1}]", InnerQuery, TableName));
            queryStringBuilder.Append(string.Format(" LIMIT {0} OFFSET {1}", CountToTake, CountToSkip));
            return queryStringBuilder.ToString();
        }
    }
}
