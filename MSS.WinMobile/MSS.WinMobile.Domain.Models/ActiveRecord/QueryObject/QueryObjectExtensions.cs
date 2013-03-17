using System.Linq;
using System.Text;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public static class QueryObjectExtensions
    {
        public static IQueryObject<T> Where<T>(this IQueryObject<T> queryObject, string fieldName, Condition condition)
        {
            if (!queryObject.FieldsNames.Contains(fieldName))
                throw new FieldNotExistException(queryObject.TableName, fieldName);

            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT ");
            for (int i = 0; i < queryObject.FieldsNames.Length; i++)
            {
                if (i > 0)
                    queryStringBuilder.Append(", ");

                queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}]", queryObject.TableName, queryObject.FieldsNames[i]));
            }
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [{1}]", queryObject.Query, queryObject.TableName));
            queryStringBuilder.Append(string.Format(" WHERE [{0}].[{1}] {2}", queryObject.TableName, fieldName, condition));

            var queryObjectFactory = new QueryObjectFactory();
            return queryObjectFactory.CreateQueryObject(queryObject);
        }

        public static IOrderedQueryObject<T> OrderBy<T>(this IQueryObject<T> queryObject, string fieldName, OrderDirection orderDirection)
        {
            if (!queryObject.FieldsNames.Contains(fieldName))
                throw new FieldNotExistException(queryObject.TableName, fieldName);

            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT ");
            for (int i = 0; i < queryObject.FieldsNames.Length; i++)
            {
                if (i > 0)
                    queryStringBuilder.Append(", ");

                queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}]", queryObject.TableName, queryObject.FieldsNames[i]));
            }
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [{1}]", queryObject.Query, queryObject.TableName));
            queryStringBuilder.Append(string.Format(" ORDER BY [{0}].[{1}] ", queryObject.TableName, fieldName));
            queryStringBuilder.Append(orderDirection == OrderDirection.Asceding ? "ASC" : "DESC");
            return new OrderedQueryObject<T>(queryObject, fieldName);
        }
    }
}
