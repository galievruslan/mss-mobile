using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;
using log4net;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Order : ActiveRecordBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Order));

        internal Order(IDataRecord record, string fieldPrefix)
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
                    case Table.Fields.DATE:
                        {
                            Date = record.GetDateTime(i);
                            break;
                        }
                    case Table.Fields.MANAGER_ID:
                        {
                            Manager = new Manager(record, Manager.Table.TABLE_NAME + "_");
                            break;
                        }
                    case Table.Fields.NOTE:
                        {
                            Note = record.GetString(i);
                            break;
                        }
                    case Table.Fields.PRICE_LIST_ID:
                        {
                            PriceList = new PriceList(record, PriceList.Table.TABLE_NAME + "_");
                            break;
                        }
                    case Table.Fields.SHIPPING_ADDRESS_ID:
                        {
                            ShippingAddress = new ShippingAddress(record, ShippingAddress.Table.TABLE_NAME + "_");
                            break;
                        }
                    case Table.Fields.WAREHOUSE_ID:
                        {
                            Warehouse = new Warehouse(record, Warehouse.Table.TABLE_NAME + "_");
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "Orders";

            public static class Fields
            {
                public const string ID = "Id";
                public const string DATE = "Date";
                public const string SHIPPING_ADDRESS_ID = "ShippingAddress_Id";
                public const string MANAGER_ID = "Manager_Id";
                public const string PRICE_LIST_ID = "PriceList_Id";
                public const string WAREHOUSE_ID = "Warehouse_Id";
                public const string NOTE = "Note";
            }    
        }

        public static Order GetById(int id)
        {
            return new OrderQueryObject().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
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
                                     Date.ToString("yyyy-MM-dd HH:mm:ss"),
                                     ShippingAddress != null
                                         ? ShippingAddress.Id.ToString(CultureInfo.InvariantCulture)
                                         : "NULL",
                                     Manager != null ? Manager.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                     PriceList != null ? PriceList.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                     Warehouse != null ? Warehouse.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                     string.IsNullOrEmpty(Note) ? string.Empty : Note.Replace("'", "''"));
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
            string scriptPath = string.Format("{0}\\Resources\\Database\\Queries\\{1}", Environments.AppPath, GetType());
            string saveScriptPath = string.Format("{0}{1}", scriptPath, SavePostfix);
            string deleteScriptPath = string.Format("{0}{1}", scriptPath, DeletePostfix);

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
