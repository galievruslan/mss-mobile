using System.Collections.Generic;
using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class OrderItem : ActiveRecordBase
    {
        internal OrderItem(IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(Table.Fields.ID))
                Id = (int)dictionary[Table.Fields.ID];

            if (dictionary.ContainsKey(Table.Fields.ORDER_ID))
                OrderId = (int)dictionary[Table.Fields.ORDER_ID];

            if (dictionary.ContainsKey(Table.Fields.PRODUCT_ID))
                ProductId = (int)dictionary[Table.Fields.PRODUCT_ID];

            if (dictionary.ContainsKey(Table.Fields.QUANTITY))
                Quantity = (int)dictionary[Table.Fields.QUANTITY];
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
                                     Table.TABLE_NAME, Table.Fields.ORDER_ID, OrderId,
                                     Table.Fields.PRODUCT_ID, ProductId,
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
    }
}
