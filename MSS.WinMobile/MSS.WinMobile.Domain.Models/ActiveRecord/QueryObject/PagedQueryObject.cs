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

        public override string ToString()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append(string.Format("{0} LIMIT {1} OFFSET {2}", InnerQuery, CountToTake, CountToSkip));
            return queryStringBuilder.ToString();
        }
    }
}
