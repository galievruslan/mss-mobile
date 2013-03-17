using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public abstract class QueryObject<T> : IEnumerable<T>, IQueryObject<T>
    {
        public string TableName { get; protected set; }
        public string[] FieldsNames { get; protected set; }

        protected QueryObject(string tableName, string[] fieldsNames)
        {
            TableName = tableName;
            FieldsNames = fieldsNames;
        }

        private readonly IQueryObject<T> _innerQuery; 

        protected QueryObject(IQueryObject<T> queryObject)
            :this(queryObject.TableName, queryObject.FieldsNames)
        {
            _innerQuery = queryObject;
        }

        public string BuildQuery()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT ");
            for (int i = 0; i < FieldsNames.Length; i++)
            {
                if (i > 0)
                    queryStringBuilder.Append(", ");

                queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}]", TableName, FieldsNames[i]));
            }

            queryStringBuilder.Append(_innerQuery == null
                                          ? string.Format(" FROM [{0}] AS [{0}]", TableName)
                                          : string.Format(" FROM ({0}) AS [{1}]", _innerQuery.BuildQuery(), TableName));

            return queryStringBuilder.ToString();
        }

        public abstract IEnumerator<T> GetEnumerator();

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
