using System;
using System.Collections;
using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Data
{
    public interface IQueryObject<TModel, TQuery, TConnection, TQueryResult> : IEnumerable<TModel> where TModel : IModel
    {
        IConnectionFactory<TConnection> ConnectionFactory { get; }
        ITranslator<TModel, TQueryResult> Translator { get; }
        TQuery AsQuery();
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
}