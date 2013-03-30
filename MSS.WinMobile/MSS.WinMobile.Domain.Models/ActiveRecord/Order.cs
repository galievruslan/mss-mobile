using System;
using System.Collections.Generic;
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
        internal Order(IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(Table.Fields.ID))
                Id = (int)dictionary[Table.Fields.ID];
            if (dictionary.ContainsKey(Table.Fields.DATE))
                Date = DateTime.Parse(dictionary[Table.Fields.DATE].ToString());
            if (dictionary.ContainsKey(Table.Fields.NOTE))
                Note = dictionary[Table.Fields.NOTE].ToString();

            // Fill Order's ShippingAddress object if exist
            string shippingAddressKeyPrefix = string.Format("{0}_", ShippingAddress.Table.TABLE_NAME);
            var shippingAddressDictionary =
                dictionary.Where(pair => pair.Key.StartsWith(shippingAddressKeyPrefix))
                          .ToArray()
                          .ToDictionary(keyValuePair => keyValuePair.Key.Replace(shippingAddressKeyPrefix, ""),
                                        keyValuePair => keyValuePair.Value);
            if (shippingAddressDictionary.Any())
            {
                ShippingAddress = new ShippingAddress(shippingAddressDictionary);
            }

            // Fill Order's Customer object if exist
            string customerKeyPrefix = string.Format("{0}_", Customer.Table.TABLE_NAME);
            var customerDictionary =
                dictionary.Where(pair => pair.Key.StartsWith(customerKeyPrefix))
                          .ToArray()
                          .ToDictionary(keyValuePair => keyValuePair.Key.Replace(customerKeyPrefix, ""),
                                        keyValuePair => keyValuePair.Value);
            if (customerDictionary.Any())
            {
                Customer = new Customer(customerDictionary);
            }

            // Fill Order's Manager object if exist
            string managerKeyPrefix = string.Format("{0}_", Manager.Table.TABLE_NAME);
            var managerDictionary =
                dictionary.Where(pair => pair.Key.StartsWith(managerKeyPrefix))
                          .ToArray()
                          .ToDictionary(keyValuePair => keyValuePair.Key.Replace(managerKeyPrefix, ""),
                                        keyValuePair => keyValuePair.Value);
            if (managerDictionary.Any())
            {
                Manager = new Manager(managerDictionary);
            }

            // Fill Order's PriceList object if exist
            string priceListKeyPrefix = string.Format("{0}_", PriceList.Table.TABLE_NAME);
            var priceListDictionary =
                dictionary.Where(pair => pair.Key.StartsWith(priceListKeyPrefix))
                          .ToArray()
                          .ToDictionary(keyValuePair => keyValuePair.Key.Replace(priceListKeyPrefix, ""),
                                        keyValuePair => keyValuePair.Value);
            if (priceListDictionary.Any())
            {
                PriceList = new PriceList(priceListDictionary);
            }

            // Fill Order's Warehouse object if exist
            string warehouseKeyPrefix = string.Format("{0}_", Warehouse.Table.TABLE_NAME);
            var warehouseDictionary =
                dictionary.Where(pair => pair.Key.StartsWith(warehouseKeyPrefix))
                          .ToArray()
                          .ToDictionary(keyValuePair => keyValuePair.Key.Replace(warehouseKeyPrefix, ""),
                                        keyValuePair => keyValuePair.Value);
            if (warehouseDictionary.Any())
            {
                Warehouse = new Warehouse(warehouseDictionary);
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
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.ID));
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.DATE));
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.MANAGER_ID));
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.SHIPPING_ADDRESS_ID));
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.PRICE_LIST_ID));
                insertBuilder.Append(string.Format("[{0}], ", Table.Fields.WAREHOUSE_ID));
                insertBuilder.Append(string.Format("[{0}]", Table.Fields.NOTE));
                insertBuilder.Append(") VALUES (");
                insertBuilder.Append(string.Format("{0}, ", Id));
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
