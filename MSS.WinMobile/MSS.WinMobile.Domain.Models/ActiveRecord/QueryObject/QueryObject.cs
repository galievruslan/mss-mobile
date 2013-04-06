using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using log4net;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class QueryObject<T> : IEnumerable<T> where T : ActiveRecordBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(QueryObject<T>));

        public string TableName { get; protected set; }
        public string[] FieldsNames { get; protected set; }

        public QueryObject(string tableName, string[] fieldsNames)
        {
            TableName = tableName;
            FieldsNames = fieldsNames;
        }

        public QueryObject<T> InnerQuery { get; protected set; }

        protected QueryObject(QueryObject<T> queryObject)
            :this(queryObject.TableName, queryObject.FieldsNames)
        {
            InnerQuery = queryObject;
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

            queryStringBuilder.Append(InnerQuery == null
                                          ? string.Format(" FROM [{0}] AS [{0}]", TableName)
                                          : string.Format(" FROM ({0}) AS [{1}]", InnerQuery, TableName));

            return queryStringBuilder.ToString();
        }

        protected virtual T[] Execute()
        {
            Log.DebugFormat("Select from database.");
            string commandText = ToString();

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
                            result.Add(ActiveRecordFactory.Create<T>(reader));
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

    public class ObjectEnumerator<T> : IEnumerator<T>
    {
        readonly T[] _objects;
        private int _position = -1;

        public ObjectEnumerator(T[] objects)
        {
            _objects = objects;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _objects.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public T Current
        {
            get
            {
                try
                {
                    return _objects[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose()
        {
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
