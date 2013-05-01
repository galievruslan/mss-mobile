using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Infrastructure.Data;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public abstract class QueryObject<TModel> : IQueryObject<TModel, string, SQLiteConnection, IDataReader> where TModel : IModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(QueryObject<TModel>));

        public ITranslator<TModel, IDataReader> Translator { get; private set; }
        public IConnectionFactory<SQLiteConnection> ConnectionFactory { get; private set; }
        protected QueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<TModel, IDataReader> translator)
        {
            Translator = translator;
            ConnectionFactory = connectionFactory;
        }

        public IQueryObject<TModel, string, SQLiteConnection, IDataReader> InnerQueryObject { get; protected set; }
        protected QueryObject(IQueryObject<TModel, string, SQLiteConnection, IDataReader> queryObject)
            :this(queryObject.ConnectionFactory, queryObject.Translator)
        {
            InnerQueryObject = queryObject;
        }

        public abstract string AsQuery();

        protected virtual TModel[] Execute()
        {
            Log.DebugFormat("Select from database.");
            string commandText = AsQuery(); 

            try
            {
                IDbConnection connection = ConnectionFactory.CurrentConnection;
                using (IDbCommand command = connection.CreateCommand())
                {   
                    command.CommandText = commandText;
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        return Translator.Translate(reader);
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(string.Format("Query: {0}", commandText), exception);
            }

            return new TModel[0];
        }

        public IEnumerator<TModel> GetEnumerator()
        {
            return new ObjectEnumerator<TModel>(Execute());
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
