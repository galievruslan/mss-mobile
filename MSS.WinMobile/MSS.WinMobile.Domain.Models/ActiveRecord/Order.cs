using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
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

        protected override string InsertCommand {
            get
            {
                var insertBuilder = new StringBuilder();
                insertBuilder.Append(string.Format("INSERT INTO [{0}] (", Table.TABLE_NAME));
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.DATE));
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.MANAGER_ID));
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.SHIPPING_ADDRESS_ID));
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.PRICE_LIST_ID));
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.WAREHOUSE_ID));
                insertBuilder.Append(string.Format("[{0}]", Table.Fields.NOTE));
                insertBuilder.Append(") VALUES (");
                insertBuilder.Append(string.Format("'{0}', ", Date.ToString("yyyy-MM-dd HH:mm:ss")));
                insertBuilder.Append(Manager != null ? string.Format("{0}, ", Manager.Id) : "NULL, ");
                insertBuilder.Append(ShippingAddress != null ? string.Format("{0}, ", ShippingAddress.Id) : "NULL, ");
                insertBuilder.Append(PriceList != null ? string.Format("{0}, ", PriceList.Id) : "NULL, ");
                insertBuilder.Append(Warehouse != null ? string.Format("{0}, ", Warehouse.Id) : "NULL, ");
                insertBuilder.Append(string.Format("'{0}')", Note));

                return insertBuilder.ToString();
            }
        }

        protected override string UpdateCommand {
            get
            {
                var updateBuilder = new StringBuilder();
                updateBuilder.Append(string.Format("UPDATE [{0}] SET ", Table.TABLE_NAME));
                updateBuilder.Append(string.Format("[{0}] = '{1}', ", Table.Fields.DATE,
                                                   Date.ToString("yyyy-MM-dd HH:mm:ss")));
                updateBuilder.Append(string.Format("[{0}] = {1}, ", Table.Fields.MANAGER_ID,
                                                   Manager != null
                                                       ? Manager.Id.ToString(CultureInfo.InvariantCulture)
                                                       : "NULL"));
                updateBuilder.Append(string.Format("[{0}] = {1}, ", Table.Fields.SHIPPING_ADDRESS_ID,
                                                   ShippingAddress != null
                                                       ? ShippingAddress.Id.ToString(CultureInfo.InvariantCulture)
                                                       : "NULL"));
                updateBuilder.Append(string.Format("[{0}] = {1}, ", Table.Fields.PRICE_LIST_ID,
                                                   PriceList != null
                                                       ? PriceList.Id.ToString(CultureInfo.InvariantCulture)
                                                       : "NULL"));
                updateBuilder.Append(string.Format("[{0}] = {1}, ", Table.Fields.WAREHOUSE_ID,
                                                   Warehouse != null
                                                       ? Warehouse.Id.ToString(CultureInfo.InvariantCulture)
                                                       : "NULL"));
                updateBuilder.Append(string.Format("[{0}] = '{1}' ", Table.Fields.NOTE, Note));
                updateBuilder.Append(string.Format("WHERE {0} = {1}", Table.Fields.ID, Id));
                return updateBuilder.ToString();
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
            return QueryObjectFactory.CreateQueryObject<Order>().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
        }
    }
}
