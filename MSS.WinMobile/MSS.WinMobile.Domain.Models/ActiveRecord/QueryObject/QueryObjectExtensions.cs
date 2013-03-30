﻿using System.Data;
using System.Linq;
using System.Text;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;
using log4net;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public static class QueryObjectExtensions
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(QueryObjectExtensions));

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

            string commandText = queryStringBuilder.ToString();
            Log.DebugFormat("Query execution requested ({0})", commandText);

            int count;
            if (!Cache.Contains(commandText))
            {
                IDbConnection connection = ConnectionFactory.GetConnection();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandText;

                    Log.DebugFormat("Query execution command prepared");
                    object result = command.ExecuteScalar();
                    Log.DebugFormat("Query execution command executed");

                    count = (int) result;
                    Cache.Add(commandText, count);
                }
            }
            else
            {
                count = Cache.Get<int>(commandText);
            }

            return count;
        }
    }
}
