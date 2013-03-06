using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class ProductsPrice : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "ProductsPrices";

            public static class Fields
            {
                public const string PRODUCT_PRICE_ID = "Id";
                public const string PRODUCT_ID = "Product_Id";
                public const string PRICE_LIST_ID = "PriceList_Id";
                public const string PRODUCT_PRICE_VALUE = "Price";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}]) VALUES ({5}, {6}, {7}, {8})",
                                     Table.NAME, Table.Fields.PRODUCT_PRICE_ID, Table.Fields.PRODUCT_ID,
                                     Table.Fields.PRICE_LIST_ID, Table.Fields.PRODUCT_PRICE_VALUE, Id, ProductId,
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
                                     Table.NAME, Table.Fields.PRODUCT_ID, ProductId,
                                     Table.Fields.PRICE_LIST_ID, PriceListId,
                                     Table.Fields.PRODUCT_PRICE_VALUE, Price, Table.Fields.PRODUCT_PRICE_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.PRODUCT_PRICE_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] FROM [{4}] AS [{4}]",
                          Table.Fields.PRODUCT_PRICE_ID, Table.Fields.PRODUCT_ID, Table.Fields.PRICE_LIST_ID,
                          Table.Fields.PRODUCT_PRICE_VALUE,
                          Table.NAME);

        public static ProductsPrice GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] " +
                                             "FROM ({4}) AS [{5}]" +
                                             "WHERE [{5}].[{0}] = {6}", Table.Fields.PRODUCT_PRICE_ID,
                                             Table.Fields.PRODUCT_ID, Table.Fields.PRICE_LIST_ID,
                                             Table.Fields.PRODUCT_PRICE_VALUE, BaseSelect,
                                             Table.NAME, id);

            using (IDbConnection connection = new SqlCeConnection())
            {
                using (connection.BeginTransaction())
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = selectString;
                        using (IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            return Materialize(reader).FirstOrDefault();
                        }
                    }
                }
            }
        }

        private static ProductsPrice[] Materialize(IDataReader reader)
        {
            var productsPrices = new List<ProductsPrice>();
            if (reader != null && reader.Read())
            {
                var productsPrice = new ProductsPrice
                    {
                        Id = (int) reader[Table.Fields.PRODUCT_PRICE_ID],
                        ProductId = (int)reader[Table.Fields.PRODUCT_ID],
                        PriceListId = (int)reader[Table.Fields.PRICE_LIST_ID],
                        Price = (decimal)reader[Table.Fields.PRODUCT_PRICE_VALUE]
                    };
                productsPrices.Add(productsPrice);
            }

            return productsPrices.ToArray();
        }
    }
}
