using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Route : ActiveRecordBase
    {
        internal Route(IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(Table.Fields.ID))
                Id = (int)dictionary[Table.Fields.ID];

            if (dictionary.ContainsKey(Table.Fields.DATE))
                Date = DateTime.Parse(dictionary[Table.Fields.DATE].ToString());

            if (dictionary.ContainsKey(Table.Fields.MANAGER_ID))
                ManagerId = (int)dictionary[Table.Fields.MANAGER_ID];
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
                                     Table.TABLE_NAME, Table.Fields.ID, Table.Fields.DATE, Table.Fields.MANAGER_ID, Id, Date, ManagerId);
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
            var queryObject = QueryObjectFactory.CreateQueryObject<Route>();
            queryObject.Where(Table.Fields.ID, new Equals(id));
            return queryObject.FirstOrDefault();
        }

        public static Route GetByDate(DateTime date)
        {
            var queryObject = QueryObjectFactory.CreateQueryObject<Route>();
            queryObject.Where(Table.Fields.DATE, new Equals(date));
            return queryObject.FirstOrDefault();
        }
    }
}
