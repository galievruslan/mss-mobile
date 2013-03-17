using System.Collections.Generic;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class OrderedQueryObject<T> : IQueryObject<T>, IOrderedQueryObject<T>
    {
        public string OrderByField { get; protected set; }
        public OrderDirection OrderDirection { get; protected set; }
        private readonly IQueryObject<T> _queryObject;

        public OrderedQueryObject(IQueryObject<T> queryObject, string orderByField, OrderDirection orderDirection)
        {
            _queryObject = queryObject;
            OrderByField = orderByField;
            OrderDirection = orderDirection;
        }

        public string TableName {
            get { return _queryObject.TableName; }
        }
        public string[] FieldsNames {
            get { return _queryObject.FieldsNames; }
        }
        public string Query {
            get { return _queryObject.Query; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _queryObject.GetEnumerator();
        }
    }

    public enum OrderDirection
    {
        Asceding,
        Desceding
    }
}
