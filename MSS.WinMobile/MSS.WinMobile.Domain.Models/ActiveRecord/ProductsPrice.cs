using System.Collections.Generic;
using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class ProductsPrice : ActiveRecordBase
    {
        internal ProductsPrice(IDataRecord record, string fieldPrefix)
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
                    case Table.Fields.PRICE_LIST_ID:
                        {
                            PriceListId = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.PRODUCT_ID:
                        {
                            ProductId = record.GetInt32(i);
                            Product = new Product(record, Product.Table.TABLE_NAME + "_");
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "ProductsPrices";

            public static class Fields
            {
                public const string ID = "Id";
                public const string PRODUCT_ID = "Product_Id";
                public const string PRICE_LIST_ID = "PriceList_Id";
                public const string VALUE = "Price";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}]) VALUES ({5}, {6}, {7}, {8})",
                                     Table.TABLE_NAME, Table.Fields.ID, Table.Fields.PRODUCT_ID,
                                     Table.Fields.PRICE_LIST_ID, Table.Fields.VALUE, Id, ProductId,
                                     PriceListId, Price);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = {2}, " +
                                     "[{3}] = {4}, " +
                                     "[{5}] = {6}" +
                                     "WHERE [{7}] = {8}",
                                     Table.TABLE_NAME, Table.Fields.PRODUCT_ID, ProductId,
                                     Table.Fields.PRICE_LIST_ID, PriceListId,
                                     Table.Fields.VALUE, Price, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.TABLE_NAME, Table.Fields.ID, Id);
            }
        }

        public static ProductsPrice GetById(int id)
        {
            return 
                QueryObjectFactory.CreateQueryObject<ProductsPrice>()
                                  .Where(Table.Fields.ID, new Equals(id))
                                  .FirstOrDefault();
        }

        public static QueryObject<ProductsPrice> GetByPriceList(PriceList priceList)
        {
            return new ProductPriceQueryObject().Where(Table.Fields.PRICE_LIST_ID, new Equals(priceList.Id));
        }
    }
}
