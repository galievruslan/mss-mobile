using System;
using System.Text;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject
{
    public class RoutePointQueryObject : QueryObject<RoutePoint>
    {
        public RoutePointQueryObject()
            : base(
                RoutePoint.Table.TABLE_NAME,
                new[]
                    {
                        string.Format(@"{0}", RoutePoint.Table.Fields.ID), 
                        string.Format(@"{0}", RoutePoint.Table.Fields.ROUTE_ID), 
                        string.Format(@"{0}", RoutePoint.Table.Fields.ORDER_ID),
                        string.Format(@"{0}", RoutePoint.Table.Fields.SHIPPING_ADDRESS_ID), 
                        string.Format(@"{0}", RoutePoint.Table.Fields.STATUS_ID),
                        string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME, ShippingAddress.Table.Fields.ID),
                        string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME, ShippingAddress.Table.Fields.CUSTOMER_ID),
                        string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME, ShippingAddress.Table.Fields.NAME),
                        string.Format(@"{0}_{1}", ShippingAddress.Table.TABLE_NAME, ShippingAddress.Table.Fields.ADDRESS)
                    })
        {
        }

        protected RoutePointQueryObject(QueryObject<RoutePoint> queryObject) : base(queryObject)
        {
            throw new NotSupportedException("RoutePointQueryObject can't wrap another QueryObjects");
        }

        public override string ToString()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT ");
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", RoutePoint.Table.TABLE_NAME,
                                                    RoutePoint.Table.Fields.ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", RoutePoint.Table.TABLE_NAME,
                                                    RoutePoint.Table.Fields.ROUTE_ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", RoutePoint.Table.TABLE_NAME,
                                                    RoutePoint.Table.Fields.ORDER_ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", RoutePoint.Table.TABLE_NAME,
                                                    RoutePoint.Table.Fields.SHIPPING_ADDRESS_ID));
            queryStringBuilder.Append(string.Format("[{0}].[{1}] AS [{1}], ", RoutePoint.Table.TABLE_NAME,
                                                    RoutePoint.Table.Fields.STATUS_ID));
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

            queryStringBuilder.Append(string.Format(" FROM [{0}] AS [{0}]", RoutePoint.Table.TABLE_NAME));
            queryStringBuilder.Append(" LEFT OUTER JOIN");
            queryStringBuilder.Append(string.Format(" [{0}] AS [{0}] ON [{1}].[{2}] = [{0}].[{3}]", 
                ShippingAddress.Table.TABLE_NAME,
                RoutePoint.Table.TABLE_NAME,
                RoutePoint.Table.Fields.SHIPPING_ADDRESS_ID,
                ShippingAddress.Table.Fields.ID));

            return queryStringBuilder.ToString();
        }
    }
}
