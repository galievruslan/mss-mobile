﻿using System;
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

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}]) VALUES ({4}, '{5}', {6})",
                                     Table.TABLE_NAME, Table.Fields.ID, Table.Fields.DATE, Table.Fields.MANAGER_ID, Id, Date.ToString("yyyy-MM-dd HH:mm:ss"), ManagerId);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}', " +
                                     "[{3}] = {4} " +
                                     "WHERE [{5}] = {6}",
                                     Table.TABLE_NAME, Table.Fields.DATE, Date,
                                     Table.Fields.MANAGER_ID, ManagerId, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.TABLE_NAME, Table.Fields.ID, Id);
            }
        }

        public static Route GetById(int id)
        {
            return QueryObjectFactory.CreateQueryObject<Route>().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
        }

        public static Route GetByDate(DateTime date)
        {
            return 
                QueryObjectFactory.CreateQueryObject<Route>()
                                  .Where(Table.Fields.DATE, new Equals(date))
                                  .FirstOrDefault();
        }
    }
}
