using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Product : ActiveRecordBase
    {
        internal Product(IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(Table.Fields.ID))
                Id = (int)dictionary[Table.Fields.ID];

            if (dictionary.ContainsKey(Table.Fields.NAME))
                Name = dictionary[Table.Fields.NAME].ToString();

            if (dictionary.ContainsKey(Table.Fields.CATEGORY_ID))
            {
                try
                {
                    CategoryId = int.Parse(dictionary[Table.Fields.CATEGORY_ID].ToString());
                }
                catch
                {
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "Products";

            public static class Fields
            {
                public const string ID = "Id";
                public const string NAME = "Name";
                public const string CATEGORY_ID = "Category_Id";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}]) VALUES ({4}, '{5}', {6})",
                                     Table.TABLE_NAME, Table.Fields.ID, Table.Fields.NAME,
                                     Table.Fields.CATEGORY_ID, Id, Name, CategoryId);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}', " +
                                     "[{3}] = {4} " +
                                     "WHERE [{5}] = {6}",
                                     Table.TABLE_NAME, Table.Fields.NAME, Name,
                                     Table.Fields.CATEGORY_ID, CategoryId, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.TABLE_NAME, Table.Fields.ID, Id);
            }
        }

        public static Product GetById(int id)
        {
            var queryObject = QueryObjectFactory.CreateQueryObject<Product>();
            queryObject.Where(Table.Fields.ID, new Equals(id));
            return queryObject.FirstOrDefault();
        }
    }
}
