using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Warehouse : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "Warehouses";

            public static class Fields
            {
                public const string WAREHOUSE_ID = "Id";
                public const string WAREHOUSE_ADDRESS = "Address";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}]) VALUES ({3}, '{4}')",
                                     Table.NAME, Table.Fields.WAREHOUSE_ID, Table.Fields.WAREHOUSE_ADDRESS, Id, Address);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}' " +
                                            "WHERE [{3}] = {4}",
                                            Table.NAME, Table.Fields.WAREHOUSE_ADDRESS, Address, Table.Fields.WAREHOUSE_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.WAREHOUSE_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}] FROM [{2}] AS [{2}]",
                          Table.Fields.WAREHOUSE_ID, Table.Fields.WAREHOUSE_ADDRESS, Table.NAME);

        public static Warehouse GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}] " +
                                             "FROM ({2}) AS [{3}] " +
                                             "WHERE [{3}].[{0}] = {4}", Table.Fields.WAREHOUSE_ID, Table.Fields.WAREHOUSE_ADDRESS, BaseSelect,
                                             Table.NAME, id);

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

        private static Warehouse[] Materialize(IDataReader reader)
        {
            var warehouses = new List<Warehouse>();
            if (reader != null && reader.Read())
            {
                var warehouse = new Warehouse
                    {
                        Id = (int) reader[Table.Fields.WAREHOUSE_ID],
                        Address = reader[Table.Fields.WAREHOUSE_ADDRESS].ToString()
                    };
                warehouses.Add(warehouse);
            }

            return warehouses.ToArray();
        }
    }
}
