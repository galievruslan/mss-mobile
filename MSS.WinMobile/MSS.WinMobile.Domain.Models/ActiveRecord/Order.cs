using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Order : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "Orders";

            public static class Fields
            {
                public const string ID = "Id";
                public const string DATE = "Date";
                public const string SHIPPING_ADDRESS_ID = "ShippingAddress_Id";
                public const string MANAGER_ID = "Manager_Id";
                public const string NOTE = "Note";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}], [{5}]) VALUES ({6}, '{7}', {8}, {9}, '{10}')",
                                     Table.NAME, Table.Fields.ID, Table.Fields.DATE,
                                     Table.Fields.SHIPPING_ADDRESS_ID, Table.Fields.MANAGER_ID, Table.Fields.NOTE, Id, Date,
                                     ShippindAddressId, ManagerId, Note);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}', " +
                                     "[{3}] = {4}, " +
                                     "[{5}] = {6}," +
                                     "[{7}] = '{8}' " +
                                     "WHERE [{9}] = {10}",
                                     Table.NAME, Table.Fields.DATE, Date,
                                     Table.Fields.SHIPPING_ADDRESS_ID, ShippindAddressId,
                                     Table.Fields.MANAGER_ID, ManagerId, Table.Fields.NOTE, Note, Table.Fields.ID, Id);
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
            string.Format("SELECT * FROM [{0}] AS [{0}]",
                          Table.NAME);

        public static Order GetById(int id)
        {
            var selectString = string.Format("SELECT * " +
                                             "FROM ({0}) AS [{1}] " +
                                             "WHERE [{1}].[{2}] = {3}", BaseSelect,
                                             Table.NAME, Table.Fields.ID, id);

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

        private static Order[] Materialize(IDataReader reader)
        {
            var orders = new List<Order>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    var order = new Order
                        {
                            Id = (int) reader[Table.Fields.ID],
                            Date = DateTime.Parse(reader[Table.Fields.DATE].ToString()),
                            ShippindAddressId = (int) reader[Table.Fields.SHIPPING_ADDRESS_ID],                            
                            ManagerId = (int) reader[Table.Fields.MANAGER_ID],
                            Note = reader[Table.Fields.NOTE].ToString()
                        };
                    orders.Add(order);
                }
            }

            return orders.ToArray();
        }
    }
}
