using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class ShippingAddress : ActiveRecordBase
    {
        internal ShippingAddress(IDataRecord record, string fieldPrefix)
        {
            for (int i = 0; i < record.FieldCount; i++)
            {
                if (record.IsDBNull(i))
                    continue;

                string fieldName = record.GetName(i);
                if (fieldPrefix != string.Empty)
                {
                    if (fieldName.IndexOf(fieldPrefix, System.StringComparison.Ordinal) < 0)
                        continue;
                    fieldName = fieldName.Replace(fieldPrefix, string.Empty);
                }

                switch (fieldName)
                {
                    case Table.Fields.ID:
                        {
                            Id = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.NAME:
                        {
                            Name = record.GetString(i);
                            break;
                        }
                    case Table.Fields.ADDRESS:
                        {
                            Address = record.GetString(i);
                            break;
                        }
                    case Table.Fields.CUSTOMER_ID:
                        {
                            CustomerId = record.GetInt32(i);
                            break;
                        }
                }
            }
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

        public static ShippingAddress GetById(int id)
        {
            return QueryObjectFactory.CreateQueryObject<ShippingAddress>().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
        }

        public static QueryObject<ShippingAddress> GetByCustomer(Customer customer)
        {
            return
                QueryObjectFactory.CreateQueryObject<ShippingAddress>()
                                  .Where(Table.Fields.CUSTOMER_ID, new Equals(customer.Id));
        }
    }
}
