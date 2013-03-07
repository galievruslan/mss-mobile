using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Product : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "Products";

            public static class Fields
            {
                public const string PRODUCT_ID = "Id";
                public const string PRODUCT_NAME = "Name";
                public const string PRODUCT_CATEGORY_ID = "Category_Id";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}]) VALUES ({4}, '{5}', {6})",
                                     Table.NAME, Table.Fields.PRODUCT_ID, Table.Fields.PRODUCT_NAME,
                                     Table.Fields.PRODUCT_CATEGORY_ID, Id, Name, CategoryId);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}', " +
                                     "[{3}] = {4} " +
                                     "WHERE [{5}] = {6}",
                                     Table.NAME, Table.Fields.PRODUCT_NAME, Name,
                                     Table.Fields.PRODUCT_CATEGORY_ID, CategoryId, Table.Fields.PRODUCT_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.PRODUCT_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}] FROM [{3}] AS [{3}]",
                          Table.Fields.PRODUCT_ID, Table.Fields.PRODUCT_NAME, Table.Fields.PRODUCT_CATEGORY_ID,
                          Table.NAME);

        public static Product GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}] " +
                                             "FROM ({3}) AS [{4}] " +
                                             "WHERE [{4}].[{0}] = {5}", Table.Fields.PRODUCT_ID,
                                             Table.Fields.PRODUCT_NAME, Table.Fields.PRODUCT_CATEGORY_ID, BaseSelect,
                                             Table.NAME, id);

            using (IDbConnection connection = new SqlCeConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                connection.Open();
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

        private static Product[] Materialize(IDataReader reader)
        {
            var products = new List<Product>();
            if (reader != null && reader.Read())
            {
                var product = new Product
                    {
                        Id = (int) reader[Table.Fields.PRODUCT_ID],
                        Name = reader[Table.Fields.PRODUCT_NAME].ToString(),
                        CategoryId = (int?)reader[Table.Fields.PRODUCT_CATEGORY_ID]
                    };
                products.Add(product);
            }

            return products.ToArray();
        }
    }
}
