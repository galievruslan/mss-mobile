using System;
using System.Data;
using System.Data.SQLite;
using System.Text;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public static class QueryObjectExtensions
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(QueryObjectExtensions));

        public static IQueryObject<T, string, SQLiteConnection> Where<T>(this IQueryObject<T, string, SQLiteConnection> queryObject, string fieldName, Condition condition) where T : IModel
        {
            return new FiltredQueryObject<T>(queryObject, fieldName, condition);
        }

        public static OrderedQueryObject<T> OrderBy<T>(this IQueryObject<T, string, SQLiteConnection> queryObject, string fieldName, OrderDirection orderDirection) where T : IModel
        {
            return new OrderedQueryObject<T>(queryObject, fieldName, orderDirection);
        }

        public static OrderedQueryObject<T> Page<T>(this OrderedQueryObject<T> queryObject, int countToSkip, int countToTake) where T : IModel
        {
            return new PagedQueryObject<T>(queryObject, queryObject.OrderByField, queryObject.OrderDirection, countToSkip, countToTake);
        }

        public static int Count<T>(this IQueryObject<T, string, SQLiteConnection> queryObject) where T : IModel
        {
            Log.DebugFormat("Select count from database.");
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT COUNT(*)");
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [source]", queryObject.AsQuery()));

            string commandText = queryStringBuilder.ToString();

            int count;
            IDbConnection connection = queryObject.ConnectionFactory.GetConnection();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = commandText;

                object result = command.ExecuteScalar();

                count = Convert.ToInt32(result);
            }

            return count;
        }
    }
}
