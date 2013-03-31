using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class OrderItem : ActiveRecordBase
    {
        internal OrderItem(IDataRecord record, string fieldPrefix)
        {
            for (int i = 0; i < record.FieldCount; i++)
            {
                if (record.IsDBNull(i))
                    continue;

                string fieldName = record.GetName(i);
                if (fieldPrefix != string.Empty)
                    fieldName = fieldName.Replace(fieldPrefix, string.Empty);

                switch (fieldName)
                {
                    case Table.Fields.ID:
                        {
                            Id = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.ORDER_ID:
                        {
                            OrderId = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.PRODUCT_ID:
                        {
                            Product = new Product(record, Product.Table.TABLE_NAME + "_");
                            break;
                        }
                    case Table.Fields.QUANTITY:
                        {
                            Quantity = record.GetInt32(i);
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "OrderItems";

            public static class Fields
            {
                public const string ID = "Id";
                public const string ORDER_ID = "OrderId";
                public const string PRODUCT_ID = "Product_Id";
                public const string QUANTITY = "Quantity";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}]) VALUES ({5}, {6}, {7}, {8})",
                                     Table.TABLE_NAME, Table.Fields.ID, Table.Fields.ORDER_ID,
                                     Table.Fields.PRODUCT_ID, Table.Fields.QUANTITY, Id, OrderId,
                                     Product.Id, Quantity);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = {2}, " +
                                     "[{3}] = {4}, " +
                                     "[{5}] = {6}" +
                                     "WHERE [{7}] = {8}",
                                     Table.TABLE_NAME, Table.Fields.ORDER_ID, OrderId,
                                     Table.Fields.PRODUCT_ID, Product.Id,
                                     Table.Fields.QUANTITY, Quantity, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.TABLE_NAME, Table.Fields.ID, Id);
            }
        }

        public static OrderItem GetById(int id)
        {
            var queryObject = QueryObjectFactory.CreateQueryObject<OrderItem>();
            queryObject.Where(Table.Fields.ID, new Equals(id));
            return queryObject.FirstOrDefault();
        }

        public static QueryObject<OrderItem> GetByOrder(Order order)
        {
            return
                QueryObjectFactory.CreateQueryObject<OrderItem>()
                                  .Where(Table.Fields.ORDER_ID, new Equals(order.Id));
        }
    }
}
