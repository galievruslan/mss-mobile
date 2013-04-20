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
    public partial class RouteTemplate : ActiveRecordBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RouteTemplate));

        internal RouteTemplate(IDataRecord record, string fieldPrefix)
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
                    case Table.Fields.DAY_OF_WEEK:
                        {
                            DayOfWeek = (DayOfWeek)record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.MANAGER_ID:
                        {
                            ManagerId = record.GetInt32(i);
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "RouteTemplates";

            public static class Fields
            {
                public const string ID = "Id";
                public const string DAY_OF_WEEK = "DayOfWeek";
                public const string MANAGER_ID = "Manager_Id";
            }    
        }

        public static RouteTemplate GetById(int id)
        {
            return QueryObjectFactory.CreateQueryObject<RouteTemplate>().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
        }

        public static RouteTemplate GetByDayOfWeek(DayOfWeek dayOfWeek)
        {
            return 
                QueryObjectFactory.CreateQueryObject<RouteTemplate>()
                                  .Where(Table.Fields.DAY_OF_WEEK, new Equals((int)dayOfWeek))
                                  .FirstOrDefault();
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

                return string.Format(_saveCommandTemplate, Id, (int)DayOfWeek, ManagerId);
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
