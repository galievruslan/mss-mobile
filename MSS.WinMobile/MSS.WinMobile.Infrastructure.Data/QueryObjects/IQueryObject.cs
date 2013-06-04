using System;
using System.Collections;
using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Storage.QueryObjects
{
    public interface IQueryObject<TModel> : IEnumerable<TModel> where TModel : IModel {
        IQueryObject<TModel> Where(ISpecification<TModel> specification);
        IQueryObject<TModel> OrderBy(string fieldName, OrderDirection orderDirection);
        IPagedQueryObject<TModel> Paged(int countToSkip, int countToTake);
        int GetCount();
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

        object IEnumerator.Current {
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

    public enum OrderDirection {
        Asceding,
        Desceding
    }
}