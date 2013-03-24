using System;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class OrderQueryObject : QueryObject<Order>
    {
        public OrderQueryObject()
            : base(
                Order.Table.TABLE_NAME,
                new[]
                    {
                        string.Format(@"{0}", Order.Table.Fields.ID), 
                        string.Format(@"{0}", Order.Table.Fields.DATE), 
                        string.Format(@"{0}", Order.Table.Fields.MANAGER_ID),
                        string.Format(@"{0}", Order.Table.Fields.SHIPPING_ADDRESS_ID), 
                        string.Format(@"{0}", Order.Table.Fields.MANAGER_ID),
                        string.Format(@"{0}_{1}", Manager.Table.TABLE_NAME, Manager.Table.Fields.ID),
                        string.Format(@"{0}_{1}", Manager.Table.TABLE_NAME, Manager.Table.Fields.NAME),
                        string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME, ShippingAddress.Table.Fields.ID),
                        string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME, ShippingAddress.Table.Fields.CUSTOMER_ID),
                        string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME, ShippingAddress.Table.Fields.NAME),
                        string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME, ShippingAddress.Table.Fields.ADDRESS),
                        string.Format(@"{0}_{1}", Customer.Table.TABLE_NAME, Customer.Table.Fields.ID),
                        string.Format(@"{0}_{1}", Customer.Table.TABLE_NAME, Customer.Table.Fields.NAME),
                        string.Format(@"{0}_{1}", PriceList.Table.TABLE_NAME, PriceList.Table.Fields.ID),
                        string.Format(@"{0}_{1}", PriceList.Table.TABLE_NAME, PriceList.Table.Fields.NAME),
                        string.Format(@"{0}_{1}", Warehouse.Table.TABLE_NAME, Warehouse.Table.Fields.ID),
                        string.Format(@"{0}_{1}", Warehouse.Table.TABLE_NAME, Warehouse.Table.Fields.ADDRESS)
                    })
        {
        }

        protected OrderQueryObject(QueryObject<Order> queryObject) : base(queryObject)
        {
            throw new NotSupportedException("OrderQueryObject can't wrap another QuetyObjects");
        }

        public override string ToString()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT ");
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", Order.Table.TABLE_NAME,
                                                    Order.Table.Fields.ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", Order.Table.TABLE_NAME,
                                                    Order.Table.Fields.MANAGER_ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", Order.Table.TABLE_NAME,
                                                    Order.Table.Fields.DATE));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", Order.Table.TABLE_NAME,
                                                    Order.Table.Fields.SHIPPING_ADDRESS_ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", Order.Table.TABLE_NAME,
                                                    Order.Table.Fields.NOTE));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", ShippingAddress.Table.TABLE_NAME,
                                                    ShippingAddress.Table.Fields.ID,
                                                    string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME,
                                                                  ShippingAddress.Table.Fields.ID)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", ShippingAddress.Table.TABLE_NAME,
                                                    ShippingAddress.Table.Fields.CUSTOMER_ID,
                                                    string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME,
                                                                  ShippingAddress.Table.Fields.CUSTOMER_ID)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", ShippingAddress.Table.TABLE_NAME,
                                                    ShippingAddress.Table.Fields.NAME,
                                                    string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME,
                                                                  ShippingAddress.Table.Fields.NAME)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}] ", ShippingAddress.Table.TABLE_NAME,
                                                    ShippingAddress.Table.Fields.ADDRESS,
                                                    string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME,
                                                                  ShippingAddress.Table.Fields.ADDRESS)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", Manager.Table.TABLE_NAME,
                                                    Manager.Table.Fields.ID,
                                                    string.Format(@"{0}_{1}", Manager.Table.TABLE_NAME,
                                                                  Manager.Table.Fields.ID)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", Manager.Table.TABLE_NAME,
                                                    Manager.Table.Fields.NAME,
                                                    string.Format(@"{0}_{1}", Manager.Table.TABLE_NAME,
                                                                  Manager.Table.Fields.NAME)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", Customer.Table.TABLE_NAME,
                                                    Customer.Table.Fields.ID,
                                                    string.Format(@"{0}_{1}", Customer.Table.TABLE_NAME,
                                                                  Customer.Table.Fields.ID)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", Customer.Table.TABLE_NAME,
                                                    Customer.Table.Fields.NAME,
                                                    string.Format(@"{0}_{1}", Customer.Table.TABLE_NAME,
                                                                  Customer.Table.Fields.NAME)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", PriceList.Table.TABLE_NAME,
                                                    PriceList.Table.Fields.ID,
                                                    string.Format(@"{0}_{1}", PriceList.Table.TABLE_NAME,
                                                                  PriceList.Table.Fields.ID)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", PriceList.Table.TABLE_NAME,
                                                    PriceList.Table.Fields.NAME,
                                                    string.Format(@"{0}_{1}", PriceList.Table.TABLE_NAME,
                                                                  PriceList.Table.Fields.NAME)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", Warehouse.Table.TABLE_NAME,
                                                    Warehouse.Table.Fields.ID,
                                                    string.Format(@"{0}_{1}", Warehouse.Table.TABLE_NAME,
                                                                  Warehouse.Table.Fields.ID)));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{2}], ", Warehouse.Table.TABLE_NAME,
                                                    Warehouse.Table.Fields.ADDRESS,
                                                    string.Format(@"{0}_{1}", Warehouse.Table.TABLE_NAME,
                                                                  Warehouse.Table.Fields.ADDRESS)));

            queryStringBuilder.Append(string.Format(" FROM [{0}] AS [{0}]", Order.Table.TABLE_NAME));
            queryStringBuilder.Append(" LEFT OUTER JOIN");
            queryStringBuilder.Append(string.Format(" [{0}] AS [{0}] ON [{1}].[{2}] = [{0}].[{3}]",
                Manager.Table.TABLE_NAME,
                Order.Table.TABLE_NAME,
                Order.Table.Fields.MANAGER_ID,
                Manager.Table.Fields.ID));
            queryStringBuilder.Append(" LEFT OUTER JOIN");
            queryStringBuilder.Append(string.Format(" [{0}] AS [{0}] ON [{1}].[{2}] = [{0}].[{3}]", 
                ShippingAddress.Table.TABLE_NAME,
                Order.Table.TABLE_NAME,
                Order.Table.Fields.SHIPPING_ADDRESS_ID,
                ShippingAddress.Table.Fields.ID));
            queryStringBuilder.Append(" LEFT OUTER JOIN");
            queryStringBuilder.Append(string.Format(" [{0}] AS [{0}] ON [{1}].[{2}] = [{0}].[{3}]",
                Customer.Table.TABLE_NAME,
                ShippingAddress.Table.TABLE_NAME,
                ShippingAddress.Table.Fields.CUSTOMER_ID,
                Customer.Table.Fields.ID));
            queryStringBuilder.Append(" LEFT OUTER JOIN");
            queryStringBuilder.Append(string.Format(" [{0}] AS [{0}] ON [{1}].[{2}] = [{0}].[{3}]",
                PriceList.Table.TABLE_NAME,
                Order.Table.TABLE_NAME,
                Order.Table.Fields.PRICE_LIST_ID,
                PriceList.Table.Fields.ID));
            queryStringBuilder.Append(" LEFT OUTER JOIN");
            queryStringBuilder.Append(string.Format(" [{0}] AS [{0}] ON [{1}].[{2}] = [{0}].[{3}]",
                Warehouse.Table.TABLE_NAME,
                Order.Table.TABLE_NAME,
                Order.Table.Fields.WAREHOUSE_ID,
                Warehouse.Table.Fields.ID));

            return queryStringBuilder.ToString();
        }
    }
}
