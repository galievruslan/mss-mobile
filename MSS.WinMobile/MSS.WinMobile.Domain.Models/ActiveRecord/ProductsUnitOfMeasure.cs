﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class ProductsUnitOfMeasure : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "ProductsUnitOfMeasures";

            public static class Fields
            {
                public const string ID = "Id";
                public const string PRODUCT_ID = "Product_Id";
                public const string PRODUCT_UOM_ID = "UnitOfMeasure_Id";
                public const string PRODUCT_UOM_BASE = "Base";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}], [{4}]) VALUES ({5}, {6}, {7}, {8})",
                                     Table.NAME, Table.Fields.ID, Table.Fields.PRODUCT_ID,
                                     Table.Fields.PRODUCT_UOM_ID, Table.Fields.PRODUCT_UOM_BASE, Id, ProductId,
                                     UnitOfMeasureId, Base ? 1 : 0);
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
                                     Table.Fields.PRODUCT_UOM_ID, UnitOfMeasureId,
                                     Table.Fields.PRODUCT_UOM_BASE, Base ? 1 : 0, Table.Fields.ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] FROM [{4}] AS [{4}]",
                          Table.Fields.ID, Table.Fields.PRODUCT_ID, Table.Fields.PRODUCT_UOM_ID,
                          Table.Fields.PRODUCT_UOM_BASE,
                          Table.NAME);

        public static ProductsUnitOfMeasure GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}], [{3}] AS [{3}] " +
                                             "FROM ({4}) AS [{5}]" +
                                             "WHERE [{5}].[{0}] = {6}", Table.Fields.ID,
                                             Table.Fields.PRODUCT_ID, Table.Fields.PRODUCT_UOM_ID,
                                             Table.Fields.PRODUCT_UOM_BASE, BaseSelect,
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

        private static ProductsUnitOfMeasure[] Materialize(IDataReader reader)
        {
            var productsUnitOfMeasures = new List<ProductsUnitOfMeasure>();
            if (reader != null && reader.Read())
            {
                var productsUnitOfMeasure = new ProductsUnitOfMeasure
                    {
                        Id = (int) reader[Table.Fields.ID],
                        ProductId = (int)reader[Table.Fields.PRODUCT_ID],
                        UnitOfMeasureId = (int)reader[Table.Fields.PRODUCT_UOM_ID],
                        Base = (bool)reader[Table.Fields.PRODUCT_UOM_BASE]
                    };
                productsUnitOfMeasures.Add(productsUnitOfMeasure);
            }

            return productsUnitOfMeasures.ToArray();
        }
    }
}