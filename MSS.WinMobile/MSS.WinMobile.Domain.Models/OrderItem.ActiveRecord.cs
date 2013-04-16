using System;
using System.Data;
using System.Globalization;
using System.IO;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;
using log4net;

namespace MSS.WinMobile.Domain.Models
{
    public partial class OrderItem : ActiveRecordBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderItem));

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
                public const string ORDER_ID = "Order_Id";
                public const string PRODUCT_ID = "Product_Id";
                public const string QUANTITY = "Quantity";
            }    
        }

        public static QueryObject<OrderItem> GetByOrder(Order order)
        {
            return
                new OrderItemQueryObject()
                    .Where(Table.Fields.ORDER_ID, new Equals(order.Id));
        }

        private static string _saveCommandTemplate;
        protected override string SaveCommand
        {
            get
            {
                if (string.IsNullOrEmpty(_saveCommandTemplate))
                {
                    LoadScriptsTemplates();
                }

                return string.Format(_saveCommandTemplate,
                                 Id != 0 ? Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 OrderId,
                                 Product != null ? Product.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 Quantity);
            }
        }

        private static string _deleteCommandTemplate;
        protected override string DeleteCommand
        {
            get
            {
                if (string.IsNullOrEmpty(_deleteCommandTemplate))
                {
                    LoadScriptsTemplates();
                }

                return string.Format(_deleteCommandTemplate, Id);
            }
        }

        private void LoadScriptsTemplates()
        {
            string scriptPath = string.Format("{0}\\Resources\\Database\\Queries\\{1}", Context.GetAppPath(), GetType());
            string saveScriptPath = string.Format("{0}{1}", scriptPath, SAVE_POSTFIX);
            string deleteScriptPath = string.Format("{0}{1}", scriptPath, DELETE_POSTFIX);

            try
            {
                using (var reader = new StreamReader(saveScriptPath))
                {
                    _saveCommandTemplate = reader.ReadToEnd();
                }

                using (var reader = new StreamReader(deleteScriptPath))
                {
                    _deleteCommandTemplate = reader.ReadToEnd();
                }

            }
            catch (Exception exception)
            {
                Log.ErrorFormat("Type {0} registration failed!", GetType());
                Log.Fatal(exception);
            }
        }
    }
}
