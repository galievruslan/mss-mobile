using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class SkipQueryObject<T> : OrderedQueryObject<T> where T : ActiveRecordBase
    {
        public int CountToSkip { get; protected set; }

        public SkipQueryObject(QueryObject<T> queryObject, string orderByField, OrderDirection orderDirection, int countToSkip)
            :base(queryObject, orderByField, orderDirection)
        {
            CountToSkip = countToSkip;
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
            int remainder = InnerQuery.Count() - CountToSkip;

            // We can't skip value less than zero
            if (remainder < 0)
                remainder = 0;

            queryStringBuilder.Append(string.Format("SELECT TOP({0}) ", remainder));
            for (int i = 0; i < FieldsNames.Length; i++)
            {
                if (i > 0)
                    queryStringBuilder.Append(", ");

                queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}]", TableName, FieldsNames[i]));
            }
            queryStringBuilder.Append("FROM (");

            queryStringBuilder.Append(string.Format("SELECT TOP({0}) ", remainder));
            for (int i = 0; i < FieldsNames.Length; i++)
            {
                if (i > 0)
                    queryStringBuilder.Append(", ");

                queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}]", TableName, FieldsNames[i]));
            }

            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [{1}]", InnerQuery, TableName));
            queryStringBuilder.Append(string.Format(" ORDER BY [{0}].[{1}] ", TableName, OrderByField));
            queryStringBuilder.Append(OrderDirection == OrderDirection.Asceding ? "DESC" : "ASC");
            queryStringBuilder.Append(string.Format(") AS [{0}]", TableName));
            queryStringBuilder.Append(string.Format(" ORDER BY [{0}].[{1}] ", TableName, OrderByField));
            queryStringBuilder.Append(OrderDirection == OrderDirection.Asceding ? "ASC" : "DESC");

            return queryStringBuilder.ToString();
        }
    }
}
