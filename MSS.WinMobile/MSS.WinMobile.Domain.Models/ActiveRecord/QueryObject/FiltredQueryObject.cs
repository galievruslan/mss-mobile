using System.Text;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class FiltredQueryObject<T> : QueryObject<T>, IFiltredQueryObject<T> where T : ActiveRecordBase
    {
        public string FilterByField { get; protected set; }
        public Condition Condition { get; protected set; }

        public FiltredQueryObject(IQueryObject<T> queryObject, string filterByField, Condition condition)
            :base(queryObject)
        {
            FilterByField = filterByField;
            Condition = condition;
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
            queryStringBuilder.Append(string.Format(" WHERE [{0}].[{1}] {2}", TableName, FilterByField, Condition));
            return queryStringBuilder.ToString();
        }
    }
}
