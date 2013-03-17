using System.Data;
using System.Linq;
using System.Text;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public static class QueryObjectExtensions
    {
        public static IQueryObject<T> Where<T>(this IQueryObject<T> queryObject, string fieldName, Condition condition) where T : ActiveRecordBase
        {
            if (!queryObject.FieldsNames.Contains(fieldName))
                throw new FieldNotExistException(queryObject.TableName, fieldName);

            return new FiltredQueryObject<T>(queryObject, fieldName, condition);
        }

        public static IOrderedQueryObject<T> OrderBy<T>(this IQueryObject<T> queryObject, string fieldName, OrderDirection orderDirection) where T : ActiveRecordBase
        {
            if (!queryObject.FieldsNames.Contains(fieldName))
                throw new FieldNotExistException(queryObject.TableName, fieldName);

            return new OrderedQueryObject<T>(queryObject, fieldName, orderDirection);
        }

        public static int Count<T>(this IQueryObject<T> queryObject) where T : ActiveRecordBase
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT COUNT(*)");
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [{1}]", queryObject.TableName, queryObject.TableName));

            IDbConnection connection = ConnectionFactory.GetConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using (connection.BeginTransaction())
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = queryStringBuilder.ToString();
                    object count = command.ExecuteScalar();

                    return (int) count;
                }
            }
        }
    }
}
