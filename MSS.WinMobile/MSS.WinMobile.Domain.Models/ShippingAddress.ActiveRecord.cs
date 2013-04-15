using System;
using System.Data;
using System.IO;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;
using log4net;

namespace MSS.WinMobile.Domain.Models
{
    public partial class ShippingAddress : ActiveRecordBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ShippingAddress));

        internal ShippingAddress(IDataRecord record, string fieldPrefix)
        {
            for (int i = 0; i < record.FieldCount; i++)
            {
                if (record.IsDBNull(i))
                    continue;

                string fieldName = record.GetName(i);
                if (fieldPrefix != string.Empty)
                {
                    if (fieldName.IndexOf(fieldPrefix, StringComparison.Ordinal) < 0)
                        continue;
                    fieldName = fieldName.Replace(fieldPrefix, string.Empty);
                }

                switch (fieldName)
                {
                    case Table.Fields.ID:
                        {
                            Id = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.NAME:
                        {
                            Name = record.GetString(i);
                            break;
                        }
                    case Table.Fields.ADDRESS:
                        {
                            Address = record.GetString(i);
                            break;
                        }
                    case Table.Fields.CUSTOMER_ID:
                        {
                            CustomerId = record.GetInt32(i);
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "ShippingAddresses";

            public static class Fields
            {
                public const string ID = "Id";
                public const string NAME = "Name";
                public const string ADDRESS = "Address";
                public const string CUSTOMER_ID = "Customer_Id";
            }    
        }

        public static ShippingAddress GetById(int id)
        {
            return QueryObjectFactory.CreateQueryObject<ShippingAddress>().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
        }

        public static QueryObject<ShippingAddress> GetByCustomer(Customer customer)
        {
            return
                QueryObjectFactory.CreateQueryObject<ShippingAddress>()
                                  .Where(Table.Fields.CUSTOMER_ID, new Equals(customer.Id));
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

                return string.Format(_saveCommandTemplate, Id, Name.Replace("'", "''"), Address.Replace("'", "''"), CustomerId);
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
