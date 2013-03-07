using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Status : ActiveRecordBase
    {
        public static class Table
        {
            public const string NAME = "Statuses";

            public static class Fields
            {
                public const string STATUS_ID = "Id";
                public const string STATUS_NAME = "Name";
            }    
        }

        protected override string InsertCommand {
            get
            {
                return string.Format("INSERT INTO [{0}] ([{1}], [{2}]) VALUES ({3}, '{4}')",
                                     Table.NAME, Table.Fields.STATUS_ID, Table.Fields.STATUS_NAME, Id, Name);
            }
        }

        protected override string UpdateCommand {
            get
            {
                return string.Format("UPDATE [{0}] SET [{1}] = '{2}' " +
                                            "WHERE [{3}] = {4}",
                                            Table.NAME, Table.Fields.STATUS_NAME, Name, Table.Fields.STATUS_ID, Id);
            }
        }

        protected override string DeleteCommand {
            get
            {
                return string.Format("DELETE FROM [{0}] WHERE [{1}] = {2}",
                                     Table.NAME, Table.Fields.STATUS_ID, Id);
            }
        }

        private static readonly string BaseSelect =
            string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}] FROM [{2}] AS [{2}]",
                          Table.Fields.STATUS_ID, Table.Fields.STATUS_NAME, Table.NAME);

        public static Status GetById(int id)
        {
            var selectString = string.Format("SELECT [{0}] AS [{0}], [{1}] AS [{1}] " +
                                             "FROM ({2}) AS [{3}] " +
                                             "WHERE [{3}].[{0}] = {4}", Table.Fields.STATUS_ID, Table.Fields.STATUS_NAME, BaseSelect,
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

        private static Status[] Materialize(IDataReader reader)
        {
            var statuses = new List<Status>();
            if (reader != null && reader.Read())
            {
                var status = new Status
                    {
                        Id = (int) reader[Table.Fields.STATUS_ID],
                        Name = reader[Table.Fields.STATUS_NAME].ToString()
                    };
                statuses.Add(status);
            }

            return statuses.ToArray();
        }
    }
}
