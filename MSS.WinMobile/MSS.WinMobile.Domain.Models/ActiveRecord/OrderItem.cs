using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class OrderItem : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "OrderItems";

            public static class Fields
            {
                public const string ORDER_ITEM_ID = "Id";
                public const string ORDER_ID = "OrderId";
                public const string ORDER_ITEM_PRODUCT_ID = "Product_Id";
                public const string ORDER_ITEM_QUANTITY = "Quantity";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}]) VALUES ({5}, {6}, {7}, {8})",
                                     Table.NAME, Table.Fields.ORDER_ITEM_ID, Table.Fields.ORDER_ID,
                                     Table.Fields.ORDER_ITEM_PRODUCT_ID, Table.Fields.ORDER_ITEM_QUANTITY, Id, OrderId,
                                     ProductId, Quantity);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = {2}, " +
                                     "[{3}] = {4}, " +
                                     "[{5}] = {6}" +
                                     "WHERE [{7}] = {8}",
                                     Table.NAME, Table.Fields.ORDER_ID, OrderId,
                                     Table.Fields.ORDER_ITEM_PRODUCT_ID, ProductId,
                                     Table.Fields.ORDER_ITEM_QUANTITY, Quantity, Table.Fields.ORDER_ITEM_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.ORDER_ITEM_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] FROM [{4}] AS [{4}]",
                          Table.Fields.ORDER_ITEM_ID, Table.Fields.ORDER_ID, Table.Fields.ORDER_ITEM_PRODUCT_ID,
                          Table.Fields.ORDER_ITEM_QUANTITY,
                          Table.NAME);

        public static OrderItem GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] " +
                                             "FROM ({4}) AS [{5}] " +
                                             "WHERE [{5}].[{0}] = {6}", Table.Fields.ORDER_ITEM_ID,
                                             Table.Fields.ORDER_ID, Table.Fields.ORDER_ITEM_PRODUCT_ID,
                                             Table.Fields.ORDER_ITEM_QUANTITY, BaseSelect,
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

        private static OrderItem[] Materialize(IDataReader reader)
        {
            var orderItems = new List<OrderItem>();
            if (reader != null && reader.Read())
            {
                var orderItem = new OrderItem
                    {
                        Id = (int) reader[Table.Fields.ORDER_ITEM_ID],
                        OrderId = (int)reader[Table.Fields.ORDER_ID],
                        ProductId = (int)reader[Table.Fields.ORDER_ITEM_PRODUCT_ID],
                        Quantity = (int)reader[Table.Fields.ORDER_ITEM_QUANTITY]
                    };
                orderItems.Add(orderItem);
            }

            return orderItems.ToArray();
        }
    }
}
