using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Route : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "Routes";

            public static class Fields
            {
                public const string ROUTE_ID = "Id";
                public const string ROUTE_DATE = "Date";
                public const string ORDER_MANAGER_ID = "Manager_Id";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}]) VALUES ({4}, '{5}', {6})",
                                     Table.NAME, Table.Fields.ROUTE_ID, Table.Fields.ROUTE_DATE, Table.Fields.ORDER_MANAGER_ID, Id, Date, ManagerId);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}', " +
                                     "[{3}] = {4} " +
                                     "WHERE [{5}] = {6}",
                                     Table.NAME, Table.Fields.ROUTE_DATE, Date,
                                     Table.Fields.ORDER_MANAGER_ID, ManagerId, Table.Fields.ROUTE_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.ROUTE_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}] FROM [{3}] AS [{3}]",
                          Table.Fields.ROUTE_ID, Table.Fields.ROUTE_DATE,
                          Table.Fields.ORDER_MANAGER_ID,
                          Table.NAME);

        public static Route GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}] " +
                                             "FROM ({3}) AS [{4}] " +
                                             "WHERE [{4}].[{0}] = {5}", Table.Fields.ROUTE_ID,
                                             Table.Fields.ROUTE_DATE,
                                             Table.Fields.ORDER_MANAGER_ID, BaseSelect,
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

        private static Route[] Materialize(IDataReader reader)
        {
            var routes = new List<Route>();
            if (reader != null && reader.Read())
            {
                var route = new Route
                    {
                        Id = (int) reader[Table.Fields.ROUTE_ID],
                        Date = DateTime.Parse(reader[Table.Fields.ROUTE_DATE].ToString()),
                        ManagerId = (int)reader[Table.Fields.ORDER_MANAGER_ID]
                    };
                routes.Add(route);
            }

            return routes.ToArray();
        }
    }
}
