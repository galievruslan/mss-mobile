using System;
using System.Collections;
using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Data
{
    public interface IQueryObject<TM,TQ,TC> : IEnumerable<TM> where TM : IModel
    {
        TQ AsQuery();
        IConnectionFactory<TC> ConnectionFactory { get; }
        ITranslator<TM> Translator { get; }
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