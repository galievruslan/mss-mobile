using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class PriceList : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "PriceLists";

            public static class Fields
            {
                public const string PRICE_LIST_ID = "Id";
                public const string PRICE_LIST_NAME = "Name";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}]) VALUES ({3}, '{4}')",
                                     Table.NAME, Table.Fields.PRICE_LIST_ID, Table.Fields.PRICE_LIST_NAME, Id, Name);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("MODIFY [{0}] SET [{1}] = {2} " +
                                            "WHERE [{3}] = {4}",
                                            Table.NAME, Table.Fields.PRICE_LIST_NAME, Name, Table.Fields.PRICE_LIST_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.PRICE_LIST_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}] FROM [{2}] AS [{2}]",
                          Table.Fields.PRICE_LIST_ID, Table.Fields.PRICE_LIST_NAME, Table.NAME);

        public static PriceList GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}]" +
                                             "FROM ({2}) AS [{3}]" +
                                             "WHERE [{3}].[{0}] = {4}", Table.Fields.PRICE_LIST_ID, Table.Fields.PRICE_LIST_NAME, BaseSelect,
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

        private static PriceList[] Materialize(IDataReader reader)
        {
            var priceLists = new List<PriceList>();
            if (reader != null && reader.Read())
            {
                var priceList = new PriceList
                    {
                        Id = (int) reader[Table.Fields.PRICE_LIST_ID],
                        Name = reader[Table.Fields.PRICE_LIST_NAME].ToString()
                    };
                priceLists.Add(priceList);
            }

            return priceLists.ToArray();
        }
    }
}
