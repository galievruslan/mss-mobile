using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class ShippingAddress : ActiveRecordBase
    {
        internal ShippingAddress(IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(Table.Fields.ID))
                Id = (int)dictionary[Table.Fields.ID];

            if (dictionary.ContainsKey(Table.Fields.NAME))
                Name = dictionary[Table.Fields.NAME].ToString();

            if (dictionary.ContainsKey(Table.Fields.ADDRESS))
                Address = dictionary[Table.Fields.ADDRESS].ToString();

            if (dictionary.ContainsKey(Table.Fields.CUSTOMER_ID))
                CustomerId = (int)dictionary[Table.Fields.CUSTOMER_ID];
        }

        public static class Table
        {
            public const string TABLE_NAME = "ShippingAddresses";

            public static class Fields
            {
                public const string ID = "Id";
                public const string NAME = "Name";
                public const string ADDRESS = "Address";
                public const string CUSTOMER_ID = "Customer_Id";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}]) VALUES ({5}, '{6}', '{7}', {8})",
                                     Table.TABLE_NAME, Table.Fields.ID, Table.Fields.NAME,
                                     Table.Fields.ADDRESS, Table.Fields.CUSTOMER_ID, Id, Name,
                                     Address, CustomerId);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}', " +
                                     "[{3}] = '{4}', " +
                                     "[{5}] = {6}" +
                                     "WHERE [{7}] = {8}",
                                     Table.TABLE_NAME, Table.Fields.NAME, Name,
                                     Table.Fields.ADDRESS, Address,
                                     Table.Fields.CUSTOMER_ID, CustomerId, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.TABLE_NAME, Table.Fields.ID, Id);
            }
        }

        public static ShippingAddress GetById(int id)
        {
            var queryObject = QueryObjectFactory.CreateQueryObject<ShippingAddress>();
            queryObject.Where(Table.Fields.ID, new Equals(id));
            return queryObject.FirstOrDefault();
        }
    }
}
