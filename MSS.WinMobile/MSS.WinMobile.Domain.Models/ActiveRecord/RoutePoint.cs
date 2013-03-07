using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class RoutePoint : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "RoutePoints";

            public static class Fields
            {
                public const string ROUTE_POINT_ID = "Id";
                public const string ROUTE_ID = "Route_Id";
                public const string ORDER_SHIPPING_ADDRESS_ID = "ShippingAddress_Id";
                public const string ROUTE_POINT_STATUS_ID = "Status_Id";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}]) VALUES ({5}, {6}, {7}, {8})",
                                     Table.NAME, Table.Fields.ROUTE_POINT_ID, Table.Fields.ROUTE_ID,
                                     Table.Fields.ORDER_SHIPPING_ADDRESS_ID, Table.Fields.ROUTE_POINT_STATUS_ID, Id, RouteId,
                                     ShippingAddressId, StatusId);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = {2}, " +
                                     "[{3}] = {4}, " +
                                     "[{5}] = {6}" +
                                     "WHERE [{7}] = {8}",
                                     Table.NAME, Table.Fields.ROUTE_ID, RouteId,
                                     Table.Fields.ORDER_SHIPPING_ADDRESS_ID, ShippingAddressId,
                                     Table.Fields.ROUTE_POINT_STATUS_ID, StatusId, Table.Fields.ROUTE_POINT_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.ROUTE_POINT_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] FROM [{4}] AS [{4}]",
                          Table.Fields.ROUTE_POINT_ID, Table.Fields.ROUTE_ID, Table.Fields.ORDER_SHIPPING_ADDRESS_ID,
                          Table.Fields.ROUTE_POINT_STATUS_ID,
                          Table.NAME);

        public static RoutePoint GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] " +
                                             "FROM ({4}) AS [{5}] " +
                                             "WHERE [{5}].[{0}] = {6}", Table.Fields.ROUTE_POINT_ID,
                                             Table.Fields.ROUTE_ID, Table.Fields.ORDER_SHIPPING_ADDRESS_ID,
                                             Table.Fields.ROUTE_POINT_STATUS_ID, BaseSelect,
                                             Table.NAME, id);

            using (IDbConnection connection = new SqlCeConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                connection.Open();
                using (connection.BeginTransaction())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = selectString;
                        using (IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            return Materialize(reader).FirstOrDefault();
                        }
                    }
                }
            }
        }

        private static RoutePoint[] Materialize(IDataReader reader)
        {
            var routePoints = new List<RoutePoint>();
            if (reader != null && reader.Read())
            {
                var routePoint = new RoutePoint
                    {
                        Id = (int) reader[Table.Fields.ROUTE_POINT_ID],
                        RouteId = (int)reader[Table.Fields.ROUTE_ID],
                        ShippingAddressId = (int)reader[Table.Fields.ORDER_SHIPPING_ADDRESS_ID],
                        StatusId = (int)reader[Table.Fields.ROUTE_POINT_STATUS_ID]
                    };
                routePoints.Add(routePoint);
            }

            return routePoints.ToArray();
        }
    }
}
