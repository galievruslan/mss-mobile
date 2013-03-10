using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
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
                public const string ORDER_ID = "Id";
                public const string ORDER_DATE = "Date";
                public const string ORDER_SHIPPING_ADDRESS_ID = "ShippingAddress_Id";
                public const string ORDER_MANAGER_ID = "Manager_Id";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}]) VALUES ({5}, '{6}', {7}, {8})",
                                     Table.NAME, Table.Fields.ORDER_ID, Table.Fields.ORDER_DATE,
                                     Table.Fields.ORDER_SHIPPING_ADDRESS_ID, Table.Fields.ORDER_MANAGER_ID, Id, Date,
                                     ShippindAddressId, ManagerId);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = {2}, " +
                                     "[{3}] = '{4}', " +
                                     "[{5}] = {6}" +
                                     "WHERE [{7}] = {8}",
                                     Table.NAME, Table.Fields.ORDER_DATE, Date,
                                     Table.Fields.ORDER_SHIPPING_ADDRESS_ID, ShippindAddressId,
                                     Table.Fields.ORDER_MANAGER_ID, ManagerId, Table.Fields.ORDER_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.ORDER_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] FROM [{4}] AS [{4}]",
                          Table.Fields.ORDER_ID, Table.Fields.ORDER_DATE, Table.Fields.ORDER_SHIPPING_ADDRESS_ID,
                          Table.Fields.ORDER_MANAGER_ID,
                          Table.NAME);

        public static Order GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] " +
                                             "FROM ({4}) AS [{5}] " +
                                             "WHERE [{5}].[{0}] = {6}", Table.Fields.ORDER_ID,
                                             Table.Fields.ORDER_DATE, Table.Fields.ORDER_SHIPPING_ADDRESS_ID,
                                             Table.Fields.ORDER_MANAGER_ID, BaseSelect,
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

        private static Order[] Materialize(IDataReader reader)
        {
            var orders = new List<Order>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    var order = new Order
                        {
                            Id = (int) reader[Table.Fields.ORDER_ID],
                            Date = DateTime.Parse(reader[Table.Fields.ORDER_DATE].ToString()),
                            ShippindAddressId = (int) reader[Table.Fields.ORDER_SHIPPING_ADDRESS_ID],
                            ManagerId = (int) reader[Table.Fields.ORDER_MANAGER_ID]
                        };
                    orders.Add(order);
                }
            }

            return orders.ToArray();
        }
    }
}
