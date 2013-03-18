using System.Data;
using System.Linq;
using System.Text;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public static class QueryObjectExtensions
    {
        public static QueryObject<T> Where<T>(this QueryObject<T> queryObject, string fieldName, Condition condition) where T : ActiveRecordBase
        {
            if (!queryObject.FieldsNames.Contains(fieldName))
                throw new FieldNotExistException(queryObject.TableName, fieldName);

            return new FiltredQueryObject<T>(queryObject, fieldName, condition);
        }

        public static OrderedQueryObject<T> OrderBy<T>(this QueryObject<T> queryObject, string fieldName, OrderDirection orderDirection) where T : ActiveRecordBase
        {
            if (!queryObject.FieldsNames.Contains(fieldName))
                throw new FieldNotExistException(queryObject.TableName, fieldName);

            return new OrderedQueryObject<T>(queryObject, fieldName, orderDirection);
        }

        public static OrderedQueryObject<T> Skip<T>(this OrderedQueryObject<T> queryObject, int count) where T : ActiveRecordBase
        {
            QueryObject<T> baseQueryObject = queryObject;
            while (!baseQueryObject.CanBeInner)
            {
                baseQueryObject = queryObject.InnerQuery;
            }
            return new SkipQueryObject<T>(baseQueryObject, queryObject.OrderByField, queryObject.OrderDirection,  count);
        }

        public static OrderedQueryObject<T> Take<T>(this OrderedQueryObject<T> queryObject, int count) where T : ActiveRecordBase
        {
            QueryObject<T> baseQueryObject = queryObject;
            while (!baseQueryObject.CanBeInner)
            {
                baseQueryObject = queryObject.InnerQuery;
            }
            return new TakeQueryObject<T>(baseQueryObject, queryObject.OrderByField, queryObject.OrderDirection, count);
        }

        public static int Count<T>(this QueryObject<T> queryObject) where T : ActiveRecordBase
        {
            QueryObject<T> baseQueryObject = queryObject;
            while (!baseQueryObject.CanBeInner)
            {
                baseQueryObject = queryObject.InnerQuery;
            }

            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT COUNT(*)");
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [{1}]", baseQueryObject, baseQueryObject.TableName));

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
