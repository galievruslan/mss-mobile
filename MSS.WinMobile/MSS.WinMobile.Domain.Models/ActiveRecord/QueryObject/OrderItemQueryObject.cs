using System;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class OrderItemQueryObject : QueryObject<OrderItem>
    {
        public OrderItemQueryObject()
            : base(
                OrderItem.Table.TABLE_NAME,
                new[]
                    {
                        string.Format(@"{0}", OrderItem.Table.Fields.ID), 
                        string.Format(@"{0}", OrderItem.Table.Fields.ORDER_ID), 
                        string.Format(@"{0}", OrderItem.Table.Fields.PRODUCT_ID),
                        string.Format(@"{0}", OrderItem.Table.Fields.QUANTITY), 
                        string.Format(@"{0}_{1}", Product.Table.TABLE_NAME, Product.Table.Fields.ID),
                        string.Format(@"{0}_{1}", Product.Table.TABLE_NAME, Product.Table.Fields.NAME),
                        string.Format(@"{0}_{1}", Product.Table.TABLE_NAME, Product.Table.Fields.CATEGORY_ID)
                    })
        {
        }

        protected OrderItemQueryObject(QueryObject<OrderItem> queryObject)
            : base(queryObject)
        {
            throw new NotSupportedException("OrderItemQueryObject can't wrap another QueryObjects");
        }

        public override string ToString()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT ");
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", OrderItem.Table.TABLE_NAME,
                                                    OrderItem.Table.Fields.ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", OrderItem.Table.TABLE_NAME,
                                                    OrderItem.Table.Fields.ORDER_ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", OrderItem.Table.TABLE_NAME,
                                                    OrderItem.Table.Fields.PRODUCT_ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", OrderItem.Table.TABLE_NAME,
                                                    OrderItem.Table.Fields.QUANTITY));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", Product.Table.TABLE_NAME,
                                                    Product.Table.Fields.ID,
                                                    string.Format(@"{0}_{1}", Product.Table.TABLE_NAME,
                                                                  Product.Table.Fields.ID)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", Product.Table.TABLE_NAME,
                                                    Product.Table.Fields.NAME,
                                                    string.Format(@"{0}_{1}", Product.Table.TABLE_NAME,
                                                                  Product.Table.Fields.NAME)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}] ", Product.Table.TABLE_NAME,
                                                    Product.Table.Fields.CATEGORY_ID,
                                                    string.Format(@"{0}_{1}", Product.Table.TABLE_NAME,
                                                                  Product.Table.Fields.CATEGORY_ID)));

            queryStringBuilder.Append(string.Format(" FROM [{0}] AS [{0}]", OrderItem.Table.TABLE_NAME));
            queryStringBuilder.Append(" LEFT OUTER JOIN");
            queryStringBuilder.Append(string.Format(" [{0}] AS [{0}] ON [{1}].[{2}] = [{0}].[{3}]",
                Product.Table.TABLE_NAME,
                OrderItem.Table.TABLE_NAME,
                OrderItem.Table.Fields.PRODUCT_ID,
                Manager.Table.Fields.ID));

            return queryStringBuilder.ToString();
        }
    }
}
