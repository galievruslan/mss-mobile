using System;
using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class RouteTemplate : ActiveRecordBase
    {
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
    }
}
