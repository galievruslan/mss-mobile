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
    public partial class RoutePointTemplate : ActiveRecordBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePointTemplate));

        internal RoutePointTemplate(IDataRecord record, string fieldPrefix)
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
                    case Table.Fields.ROUTE_TEMPLATE_ID:
                        {
                            RouteTemplateId = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.SHIPPING_ADDRESS_ID:
                        {
                            ShippingAddressId = record.GetInt32(i);
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "RoutePointTemplates";

            public static class Fields
            {
                public const string ID = "Id";
                public const string ROUTE_TEMPLATE_ID = "RouteTemplate_Id";
                public const string SHIPPING_ADDRESS_ID = "ShippingAddress_Id";
            }    
        }

        public static RoutePointTemplate GetById(int id)
        {
            return
                QueryObjectFactory.CreateQueryObject<RoutePointTemplate>()
                    .Where(Table.Fields.ID, new Equals(id))
                    .FirstOrDefault();
        }

        public static QueryObject<RoutePointTemplate> GetByRouteTemplate(RouteTemplate routeTemplate)
        {
            return QueryObjectFactory.CreateQueryObject<RoutePointTemplate>()
                                     .Where(Table.Fields.ROUTE_TEMPLATE_ID, new Equals(routeTemplate.Id));
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

                return string.Format(_saveCommandTemplate, Id,
                RouteTemplateId,
                ShippingAddress != null ? ShippingAddress.Id.ToString(CultureInfo.InvariantCulture) : "NULL");
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
