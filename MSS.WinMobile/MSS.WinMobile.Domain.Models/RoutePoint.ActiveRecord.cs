using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;
using log4net;

namespace MSS.WinMobile.Domain.Models
{
    public partial class RoutePoint : ActiveRecordBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePoint));

        internal RoutePoint(IDataRecord record, string fieldPrefix)
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
                    case Table.Fields.ROUTE_ID:
                        {
                            RouteId = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.ORDER_ID:
                        {
                            OrderId = record.GetInt32(i);
                            Order = new Order(record, Order.Table.TABLE_NAME + "_");
                            break;
                        }
                    case Table.Fields.SHIPPING_ADDRESS_ID:
                        {
                            ShippingAddressId = record.GetInt32(i);
                            ShippingAddress = new ShippingAddress(record, ShippingAddress.Table.TABLE_NAME + "_");
                            break;
                        }
                    case Table.Fields.STATUS_ID:
                        {
                            StatusId = record.GetInt32(i);
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "RoutePoints";

            public static class Fields
            {
                public const string ID = "Id";
                public const string ROUTE_ID = "Route_Id";
                public const string SHIPPING_ADDRESS_ID = "ShippingAddress_Id";
                public const string ORDER_ID = "Order_Id";
                public const string STATUS_ID = "Status_Id";
            }    
        }

        public static RoutePoint GetById(int id)
        {
            return
                new RoutePointQueryObject()
                    .Where(Table.Fields.ID, new Equals(id))
                    .FirstOrDefault();
        }

        public static QueryObject<RoutePoint> GetByRoute(Route route)
        {
            return new RoutePointQueryObject().Where(Table.Fields.ROUTE_ID, new Equals(route.Id));
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

                return string.Format(_saveCommandTemplate, Id != 0 ? Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 RouteId,
                                 ShippingAddress != null ? ShippingAddress.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 Order != null ? Order.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                                 Status != null ? Status.Id.ToString(CultureInfo.InvariantCulture) : "NULL");
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
