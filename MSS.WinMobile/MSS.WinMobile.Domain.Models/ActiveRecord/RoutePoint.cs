using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class RoutePoint : ActiveRecordBase
    {
        internal RoutePoint(IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(Table.Fields.ID))
                Id = (int)dictionary[Table.Fields.ID];

            if (dictionary.ContainsKey(Table.Fields.ROUTE_ID))
                RouteId = (int)dictionary[Table.Fields.ROUTE_ID];

            if (dictionary.ContainsKey(Table.Fields.SHIPPING_ADDRESS_ID))
                ShippingAddressId = (int)dictionary[Table.Fields.SHIPPING_ADDRESS_ID];

            if (dictionary.ContainsKey(Table.Fields.ORDER_ID))
                OrderId = (int)dictionary[Table.Fields.ORDER_ID];

            if (dictionary.ContainsKey(Table.Fields.STATUS_ID))
                StatusId = (int)dictionary[Table.Fields.STATUS_ID];
        }


        public static class Table
        {
            public const string TABLE_NAME = "RoutePoints";

            public static class Fields
            {
                public const string ID = "Id";
                public const string ROUTE_ID = "Route_Id";
                public const string SHIPPING_ADDRESS_ID = "ShippingAddress_Id";
                public const string ORDER_ID = "Order_Id";
                public const string STATUS_ID = "Status_Id";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return
                    string.Format(
                        "INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}], [{5}]) VALUES ({6}, {7}, {8}, {9}, {10})",
                        Table.TABLE_NAME, Table.Fields.ID, Table.Fields.ROUTE_ID,
                        Table.Fields.SHIPPING_ADDRESS_ID, Table.Fields.STATUS_ID, Table.Fields.ORDER_ID, Id, RouteId,
                        ShippingAddressId, StatusId, OrderId != null
                                                         ? OrderId.ToString()
                                                         : "NULL");
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = {2}, " +
                                     "[{3}] = {4}, " +
                                     "[{5}] = {6}," +
                                     "[{7}] = {8} " +
                                     "WHERE [{9}] = {10}",
                                     Table.TABLE_NAME, Table.Fields.ROUTE_ID, RouteId,
                                     Table.Fields.SHIPPING_ADDRESS_ID, ShippingAddressId,
                                     Table.Fields.STATUS_ID, StatusId, Table.Fields.ORDER_ID, OrderId != null
                                                                                                  ? OrderId.ToString()
                                                                                                  : "NULL",
                                     Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.TABLE_NAME, Table.Fields.ID, Id);
            }
        }

        public static RoutePoint GetById(int id)
        {
            var queryObject = QueryObjectFactory.CreateQueryObject<RoutePoint>();
            queryObject.Where(Table.Fields.ID, new Equals(id));
            return queryObject.FirstOrDefault();
        }

        public static QueryObject<RoutePoint> GetByRoute(Route route)
        {
            var queryObject = QueryObjectFactory.CreateQueryObject<RoutePoint>();
            queryObject.Where(Table.Fields.ROUTE_ID, new Equals(route.Id));
            return queryObject;
        }
    }
}
