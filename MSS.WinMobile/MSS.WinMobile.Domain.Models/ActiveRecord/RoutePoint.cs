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
                public const string ID = "Id";
                public const string ROUTE_ID = "Route_Id";
                public const string SHIPPING_ADDRESS_ID = "ShippingAddress_Id";
                public const string STATUS_ID = "Status_Id";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}]) VALUES ({5}, {6}, {7}, {8})",
                                     Table.NAME, Table.Fields.ID, Table.Fields.ROUTE_ID,
                                     Table.Fields.SHIPPING_ADDRESS_ID, Table.Fields.STATUS_ID, Id, RouteId,
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
                                     Table.Fields.SHIPPING_ADDRESS_ID, ShippingAddressId,
                                     Table.Fields.STATUS_ID, StatusId, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.ID, Id);
            }
        }

        public static RoutePoint GetById(int id)
        {
            var selectString = string.Format("SELECT * " +
                                             "FROM [{0}] AS [{0}] " +
                                             "WHERE [{0}].[{1}] = {2}", Table.NAME, Table.Fields.ROUTE_ID, id);

            IDbConnection connection = GetConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using (connection.BeginTransaction()) {
                using (IDbCommand command = connection.CreateCommand()) {
                    command.CommandText = selectString;
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow)) {
                        return Materialize(reader).FirstOrDefault();
                    }
                }
            }
        }

        public static RoutePoint[] GetByRoute(Route route)
        {
            var selectString = string.Format("SELECT * " +
                                             "FROM [{0}] AS [{0}] " +
                                             "WHERE [{0}].[{1}] = {2}", Table.NAME, Table.Fields.ROUTE_ID, route.Id);

            IDbConnection connection = GetConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using (connection.BeginTransaction())
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = selectString;
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        return Materialize(reader);
                    }
                }
            }
        }

        public static int GetCountByRoute(Route route)
        {
            const string selectCountString = "SELECT Count([{0}]) From [{1}]";

            IDbConnection connection = GetConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using (connection.BeginTransaction())
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(selectCountString, Table.Fields.ID, Table.NAME);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static RoutePoint[] GetByRoute(Route route, int from, int count)
        {
            const string selectCountString = "SELECT Count([{0}]) From [{1}]";
            const string selectString = "SELECT TOP({0}) * " +
                                        "FROM (SELECT TOP({1}) * " +
                                        "FROM [{2}] AS [{2}] " +
                                        "WHERE [{2}].[{3}] = {4} " +
                                        "ORDER BY [{2}].[{5}] DESC) AS [{2}] " +
                                        "ORDER BY [{2}].[{5}] ASC ";

            IDbConnection connection = GetConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using (connection.BeginTransaction())
            {
                int totalCount;
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(selectCountString, Table.Fields.ID, Table.NAME);
                    totalCount = (int)command.ExecuteScalar();
                }
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(selectString, count, totalCount - from, Table.NAME,
                                                        Table.Fields.ROUTE_ID, route.Id, Table.Fields.ID);
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        return Materialize(reader);
                    }
                }
            }
        }

        private static RoutePoint[] Materialize(IDataReader reader)
        {
            var routePoints = new List<RoutePoint>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    var routePoint = new RoutePoint
                        {
                            Id = (int) reader[Table.Fields.ID],
                            RouteId = (int) reader[Table.Fields.ROUTE_ID],
                            ShippingAddressId = (int) reader[Table.Fields.SHIPPING_ADDRESS_ID],
                            StatusId = (int) reader[Table.Fields.STATUS_ID]
                        };
                    routePoints.Add(routePoint);
                }
            }

            return routePoints.ToArray();
        }
    }
}
