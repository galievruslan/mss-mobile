using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Warehouse : ActiveRecordBase
    {
        internal Warehouse(IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(Table.Fields.ID))
                Id = (int)dictionary[Table.Fields.ID];

            if (dictionary.ContainsKey(Table.Fields.ADDRESS))
                Address = dictionary[Table.Fields.ADDRESS].ToString();
        }

        public static class Table
        {
            public const string TABLE_NAME = "Warehouses";

            public static class Fields
            {
                public const string ID = "Id";
                public const string ADDRESS = "Address";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}]) VALUES ({3}, '{4}')",
                                     Table.TABLE_NAME, Table.Fields.ID, Table.Fields.ADDRESS, Id, Address);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}' " +
                                            "WHERE [{3}] = {4}",
                                            Table.TABLE_NAME, Table.Fields.ADDRESS, Address, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.TABLE_NAME, Table.Fields.ID, Id);
            }
        }

        public static Warehouse GetById(int id)
        {
            return
                QueryObjectFactory.CreateQueryObject<Warehouse>()
                                  .Where(Table.Fields.ID, new Equals(id))
                                  .FirstOrDefault();
        }

        public static QueryObject<Warehouse> GetAll()
        {
            return QueryObjectFactory.CreateQueryObject<Warehouse>();
        }
    }
}
