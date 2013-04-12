using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Order : ActiveRecordBase
    {
        internal Order(IDataRecord record, string fieldPrefix)
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
                            Manager = new Manager(record, Manager.Table.TABLE_NAME + "_");
                            break;
                        }
                    case Table.Fields.NOTE:
                        {
                            Note = record.GetString(i);
                            break;
                        }
                    case Table.Fields.PRICE_LIST_ID:
                        {
                            PriceList = new PriceList(record, PriceList.Table.TABLE_NAME + "_");
                            break;
                        }
                    case Table.Fields.SHIPPING_ADDRESS_ID:
                        {
                            ShippingAddress = new ShippingAddress(record, ShippingAddress.Table.TABLE_NAME + "_");
                            break;
                        }
                    case Table.Fields.WAREHOUSE_ID:
                        {
                            Warehouse = new Warehouse(record, Warehouse.Table.TABLE_NAME + "_");
                            break;
                        }
                }
            }
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
                public const string PRICE_LIST_ID = "PriceList_Id";
                public const string WAREHOUSE_ID = "Warehouse_Id";
                public const string NOTE = "Note";
            }    
        }

        public static Order GetById(int id)
        {
            return QueryObjectFactory.CreateQueryObject<Order>().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
        }
    }
}
