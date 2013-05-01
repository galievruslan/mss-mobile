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

        public static QueryObject<T> Where<T>(this IQueryObject<T, string, SQLiteConnection, IDataReader> queryObject, string fieldName, Condition condition) where T : IModel
        {
            return new FiltredQueryObject<T>(queryObject, fieldName, condition);
        }

        public static OrderedQueryObject<T> OrderBy<T>(this IQueryObject<T, string, SQLiteConnection, IDataReader> queryObject, string fieldName, OrderDirection orderDirection) where T : IModel
        {
            return new OrderedQueryObject<T>(queryObject, fieldName, orderDirection);
        }

        public static OrderedQueryObject<T> Page<T>(this OrderedQueryObject<T> queryObject, int countToSkip, int countToTake) where T : IModel
        {
            return new PagedQueryObject<T>(queryObject, queryObject.OrderByField, queryObject.OrderDirection, countToSkip, countToTake);
        }

        public static int GetCount<T>(this IQueryObject<T, string, SQLiteConnection, IDataReader> queryObject) where T : IModel
        {
            var countQueryObject = new CountQueryObject<T>(queryObject);
            return countQueryObject.Execute();
        }
    }
}
