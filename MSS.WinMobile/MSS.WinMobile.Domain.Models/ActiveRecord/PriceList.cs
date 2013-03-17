﻿using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class PriceList : ActiveRecordBase
    {
        internal PriceList(IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(Table.Fields.ID))
                Id = (int)dictionary[Table.Fields.ID];

            if (dictionary.ContainsKey(Table.Fields.NAME))
                Name = dictionary[Table.Fields.NAME].ToString();
        }

        public static class Table
        {
            public const string TABLE_NAME = "PriceLists";

            public static class Fields
            {
                public const string ID = "Id";
                public const string NAME = "Name";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}]) VALUES ({3}, '{4}')",
                                     Table.TABLE_NAME, Table.Fields.ID, Table.Fields.NAME, Id, Name);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = {2} " +
                                            "WHERE [{3}] = {4}",
                                            Table.TABLE_NAME, Table.Fields.NAME, Name, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.TABLE_NAME, Table.Fields.ID, Id);
            }
        }

        public static PriceList GetById(int id)
        {
            var queryObject = QueryObjectFactory.CreateQueryObject<PriceList>();
            queryObject.Where(Table.Fields.ID, new Equals(id));
            return queryObject.FirstOrDefault();
        }
    }
}
