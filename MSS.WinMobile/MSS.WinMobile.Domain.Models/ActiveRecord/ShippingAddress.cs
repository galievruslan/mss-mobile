using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class ShippingAddress : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "ShippingAddresses";

            public static class Fields
            {
                public const string ID = "Id";
                public const string SHIPPING_ADDRESS_NAME = "Name";
                public const string SHIPPING_ADDRESS_VALUE = "Address";
                public const string SHIPPING_ADDRESS_CUSTOMER_ID = "Customer_Id";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}]) VALUES ({5}, '{6}', '{7}', {8})",
                                     Table.NAME, Table.Fields.ID, Table.Fields.SHIPPING_ADDRESS_NAME,
                                     Table.Fields.SHIPPING_ADDRESS_VALUE, Table.Fields.SHIPPING_ADDRESS_CUSTOMER_ID, Id, Name,
                                     Address, CustomerId);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}', " +
                                     "[{3}] = '{4}', " +
                                     "[{5}] = {6}" +
                                     "WHERE [{7}] = {8}",
                                     Table.NAME, Table.Fields.SHIPPING_ADDRESS_NAME, Name,
                                     Table.Fields.SHIPPING_ADDRESS_VALUE, Address,
                                     Table.Fields.SHIPPING_ADDRESS_CUSTOMER_ID, CustomerId, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] FROM [{4}] AS [{4}]",
                          Table.Fields.ID, Table.Fields.SHIPPING_ADDRESS_NAME, Table.Fields.SHIPPING_ADDRESS_VALUE,
                          Table.Fields.SHIPPING_ADDRESS_CUSTOMER_ID,
                          Table.NAME);

        public static ShippingAddress GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] " +
                                             "FROM ({4}) AS [{5}] " +
                                             "WHERE [{5}].[{0}] = {6}", Table.Fields.ID,
                                             Table.Fields.SHIPPING_ADDRESS_NAME, Table.Fields.SHIPPING_ADDRESS_VALUE,
                                             Table.Fields.SHIPPING_ADDRESS_CUSTOMER_ID, BaseSelect,
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

        private static ShippingAddress[] Materialize(IDataReader reader)
        {
            var shippingAddresses = new List<ShippingAddress>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    var shippingAddress = new ShippingAddress
                        {
                            Id = (int) reader[Table.Fields.ID],
                            Name = reader[Table.Fields.SHIPPING_ADDRESS_NAME].ToString(),
                            Address = reader[Table.Fields.SHIPPING_ADDRESS_VALUE].ToString(),
                            CustomerId = (int) reader[Table.Fields.SHIPPING_ADDRESS_CUSTOMER_ID]
                        };
                    shippingAddresses.Add(shippingAddress);
                }
            }

            return shippingAddresses.ToArray();
        }
    }
}
