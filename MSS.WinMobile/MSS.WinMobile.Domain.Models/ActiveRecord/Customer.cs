using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Customer : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "Customers";

            public static class Fields
            {
                public const string CUSTOMER_ID = "Id";
                public const string CUSTOMER_NAME = "Name";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}]) VALUES ({3}, '{4}')",
                                     Table.NAME, Table.Fields.CUSTOMER_ID, Table.Fields.CUSTOMER_NAME, Id, Name);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}' " +
                                            "WHERE [{3}] = {4}",
                                            Table.NAME, Table.Fields.CUSTOMER_NAME, Name, Table.Fields.CUSTOMER_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.CUSTOMER_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}] FROM [{2}] AS [{2}]",
                          Table.Fields.CUSTOMER_ID, Table.Fields.CUSTOMER_NAME, Table.NAME);

        public static Customer GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}] " +
                                             "FROM ({2}) AS [{3}] " +
                                             "WHERE [{3}].[{0}] = {4}", Table.Fields.CUSTOMER_ID, Table.Fields.CUSTOMER_NAME, BaseSelect,
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

        private static Customer[] Materialize(IDataReader reader)
        {
            var customers = new List<Customer>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    var customer = new Customer
                        {
                            Id = (int) reader[Table.Fields.CUSTOMER_ID],
                            Name = reader[Table.Fields.CUSTOMER_NAME].ToString()
                        };
                    customers.Add(customer);
                }
            }

            return customers.ToArray();
        }
    }
}
