using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Category : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "Categories";

            public static class Fields
            {
                public const string CATEGORY_ID = "Id";
                public const string CATEGORY_NAME = "Name";
                public const string CATEGORY_PARENT_ID = "Parent_Id";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}], [{3}]) VALUES ({4}, '{5}', {6})",
                                     Table.NAME, Table.Fields.CATEGORY_ID, Table.Fields.CATEGORY_NAME,
                                     Table.Fields.CATEGORY_PARENT_ID, Id, Name, ParentId);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("MODIFY [{0}] SET [{1}] = '{2}', " +
                                     "[{3}] = {4} " +
                                     "WHERE [{5}] = {6}",
                                     Table.NAME, Table.Fields.CATEGORY_NAME, Name,
                                     Table.Fields.CATEGORY_PARENT_ID, ParentId, Table.Fields.CATEGORY_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.CATEGORY_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}] FROM [{3}] AS [{3}]",
                          Table.Fields.CATEGORY_ID, Table.Fields.CATEGORY_NAME, Table.Fields.CATEGORY_PARENT_ID,
                          Table.NAME);

        public static Category GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}], [{2}] AS [{2}] " +
                                             "FROM ({3}) AS [{4}]" +
                                             "WHERE [{4}].[{0}] = {5}", Table.Fields.CATEGORY_ID,
                                             Table.Fields.CATEGORY_NAME, Table.Fields.CATEGORY_PARENT_ID, BaseSelect,
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

        private static Category[] Materialize(IDataReader reader)
        {
            var categories = new List<Category>();
            if (reader != null && reader.Read())
            {
                var category = new Category
                    {
                        Id = (int) reader[Table.Fields.CATEGORY_ID],
                        Name = reader[Table.Fields.CATEGORY_NAME].ToString(),
                        ParentId = (int?)reader[Table.Fields.CATEGORY_PARENT_ID]
                    };
                categories.Add(category);
            }

            return categories.ToArray();
        }
    }
}
