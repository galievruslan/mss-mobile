using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Category : ActiveRecordBase
    {
        internal Category(IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(Table.Fields.ID))
                Id = (int)dictionary[Table.Fields.ID];

            if (dictionary.ContainsKey(Table.Fields.NAME))
                Name = dictionary[Table.Fields.NAME].ToString();

            if (dictionary.ContainsKey(Table.Fields.PARENT_ID))
            {
                try
                {
                    ParentId = int.Parse(dictionary[Table.Fields.PARENT_ID].ToString());
                }
                catch
                {
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "Categories";

            public static class Fields
            {
                public const string ID = "Id";
                public const string NAME = "Name";
                public const string PARENT_ID = "Parent_Id";
            }
        }

        protected override string InsertCommand
        {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}]) VALUES ({4}, '{5}', {6})",
                                     Table.TABLE_NAME, Table.Fields.ID, Table.Fields.NAME,
                                     Table.Fields.PARENT_ID, Id, Name, ParentId != null
                                                                                    ? ParentId.ToString()
                                                                                    : "NULL");
            }
        }

        protected override string UpdateCommand
        {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}', " +
                                     "[{3}] = {4} " +
                                     "WHERE [{5}] = {6}",
                                     Table.TABLE_NAME, Table.Fields.NAME, Name,
                                     Table.Fields.PARENT_ID, ParentId != null
                                                                          ? ParentId.ToString()
                                                                          : "NULL", Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand
        {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.TABLE_NAME, Table.Fields.ID, Id);
            }
        }

        public static Category GetById(int id)
        {
            return QueryObjectFactory.CreateQueryObject<Category>().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
        }
    }
}
