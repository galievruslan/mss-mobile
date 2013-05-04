using System;
using System.Collections;
using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.Web.QueryObjects
{
    public interface IQueryObject<TModel> : IEnumerable<TModel> where TModel : IDto {
        IQueryObject<TModel> UpdatedAfter(DateTime date);
        IPagedQueryObject<TModel> Paged(int page, int pageSize);
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