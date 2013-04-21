using System.Text;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObject;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class FiltredQueryObject<T> : QueryObject<T> where T : IModel
    {
        public string FilterByField { get; protected set; }
        public Condition Condition { get; protected set; }

        public FiltredQueryObject(IQueryObject<T,string> queryObject, string filterByField, Condition condition)
            :base(queryObject)
        {
            FilterByField = filterByField;
            Condition = condition;
        }

        public override string AsQuery()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT * ");
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [source]", InnerQueryObject.AsQuery()));
            queryStringBuilder.Append(string.Format(" WHERE [source].[{0}] {1}", FilterByField, Condition));
            return queryStringBuilder.ToString();
        }
    }
}
