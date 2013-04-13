using System;
using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Route : ActiveRecordBase
    {
        internal Route(IDataRecord record, string fieldPrefix)
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
                            ManagerId = record.GetInt32(i);
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "Routes";

            public static class Fields
            {
                public const string ID = "Id";
                public const string DATE = "Date";
                public const string MANAGER_ID = "Manager_Id";
            }    
        }

        public static Route GetById(Guid id)
        {
            return QueryObjectFactory.CreateQueryObject<Route>().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
        }

        public static Route GetByDate(DateTime date)
        {
            string cacheKey = string.Format("Route on {0}", date);

            var route = Cache.Get<Route>(cacheKey) ?? QueryObjectFactory.CreateQueryObject<Route>()
                                                                        .Where(Table.Fields.DATE, new Equals(date))
                                                                        .FirstOrDefault();

            if (route == null)
            {
                var routeTemplate = RouteTemplate.GetByDayOfWeek(DateTime.Today.DayOfWeek);
                BeginTransaction();
                route = routeTemplate != null ? routeTemplate.CreateRoute() : new Route();
                Commit();
            }

            Cache.Add(cacheKey, route);

            return route;
        }
    }
}
