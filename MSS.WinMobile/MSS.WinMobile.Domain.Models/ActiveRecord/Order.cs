using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Order : ActiveRecordBase
    {
        internal Order(IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(Table.Fields.ID))
                Id = (int)dictionary[Table.Fields.ID];

            if (dictionary.ContainsKey(Table.Fields.DATE))
                Date = DateTime.Parse(dictionary[Table.Fields.DATE].ToString());

            if (dictionary.ContainsKey(Table.Fields.SHIPPING_ADDRESS_ID))
                ShippindAddressId = (int)dictionary[Table.Fields.SHIPPING_ADDRESS_ID];

            if (dictionary.ContainsKey(Table.Fields.MANAGER_ID))
                ManagerId = (int)dictionary[Table.Fields.MANAGER_ID];

            if (dictionary.ContainsKey(Table.Fields.NOTE))
                Note = dictionary[Table.Fields.NOTE].ToString();
        }

        public static class Table
        {
            public const string TABLE_NAME = "Orders";

            public static class Fields
            {
                public const string ID = "Id";
                public const string DATE = "Date";
                public const string SHIPPING_ADDRESS_ID = "ShippingAddress_Id";
                public const string MANAGER_ID = "Manager_Id";
                public const string NOTE = "Note";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}], [{5}]) VALUES ({6}, '{7}', {8}, {9}, '{10}')",
                                     Table.TABLE_NAME, Table.Fields.ID, Table.Fields.DATE,
                                     Table.Fields.SHIPPING_ADDRESS_ID, Table.Fields.MANAGER_ID, Table.Fields.NOTE, Id, Date,
                                     ShippindAddressId, ManagerId, Note);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}', " +
                                     "[{3}] = {4}, " +
                                     "[{5}] = {6}," +
                                     "[{7}] = '{8}' " +
                                     "WHERE [{9}] = {10}",
                                     Table.TABLE_NAME, Table.Fields.DATE, Date,
                                     Table.Fields.SHIPPING_ADDRESS_ID, ShippindAddressId,
                                     Table.Fields.MANAGER_ID, ManagerId, Table.Fields.NOTE, Note, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.TABLE_NAME, Table.Fields.ID, Id);
            }
        }

        public static Order GetById(int id)
        {
            var queryObject = QueryObjectFactory.CreateQueryObject<Order>();
            queryObject.Where(Table.Fields.ID, new Equals(id));
            return queryObject.FirstOrDefault();
        }
    }
}
