﻿using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class OrderedQueryObject<T> : QueryObject<T> where T : ActiveRecordBase
    {
        public string OrderByField { get; protected set; }
        public OrderDirection OrderDirection { get; protected set; }

        public OrderedQueryObject(QueryObject<T> queryObject, string orderByField, OrderDirection orderDirection)
            :base(queryObject)
        {
            OrderByField = orderByField;
            OrderDirection = orderDirection;
        }

        public override bool CanBeInner
        {
            get
            {
                return false;
            }
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
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [{1}]", InnerQuery, TableName));
            queryStringBuilder.Append(string.Format(" ORDER BY [{0}].[{1}] ", TableName, OrderByField));
            queryStringBuilder.Append(OrderDirection == OrderDirection.Asceding ? "ASC" : "DESC");
            return queryStringBuilder.ToString();
        }
    }

    public enum OrderDirection
    {
        Asceding,
        Desceding
    }
}