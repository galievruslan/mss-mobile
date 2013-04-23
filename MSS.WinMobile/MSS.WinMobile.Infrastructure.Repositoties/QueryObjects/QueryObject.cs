using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Infrastructure.Data;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public abstract class QueryObject<T> : IQueryObject<T, string, SQLiteConnection> where T : IModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(QueryObject<T>));

        public ITranslator<T> Translator { get; private set; }
        protected QueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<T> translator)
        {
            Translator = translator;
            ConnectionFactory = connectionFactory;
        }

        public IQueryObject<T, string, SQLiteConnection> InnerQueryObject { get; protected set; }

        protected QueryObject(IQueryObject<T, string, SQLiteConnection> queryObject)
            : this(queryObject.ConnectionFactory, queryObject.Translator)
        {
            InnerQueryObject = queryObject;
        }

        public abstract string AsQuery();
        public IConnectionFactory<SQLiteConnection> ConnectionFactory { get; private set; }

        protected virtual T[] Execute()
        {
            Log.DebugFormat("Select from database.");
            string commandText = AsQuery();

            try
            {
                IDbConnection connection = ConnectionFactory.GetConnection();
                using (IDbCommand command = connection.CreateCommand())
                {
                    var result = new List<T>();
                    
                    command.CommandText = commandText;
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (reader.Read())
                        {
                            result.Add(Translator.Translate<T>(reader));
                        }
                    }
                    return result.ToArray();
                }
            }
            catch (Exception exception)
            {
                Log.Error(string.Format("Query: {0}", commandText), exception);
            }

            return new T[0];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ObjectEnumerator<T>(Execute());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class FieldNotExistException : Exception
    {
        public FieldNotExistException(string tableName, string filedName)
            :base(string.Format(@"Field ""{0}"" not exist in table ""{1}""", filedName, tableName))
        {
        }
    }
}
