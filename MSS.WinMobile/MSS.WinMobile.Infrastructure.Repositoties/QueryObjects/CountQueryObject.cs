using System;
using System.Data;
using System.Data.SQLite;
using System.Text;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class CountQueryObject<T> : QueryObject<T> where T : IModel
    {
        public CountQueryObject(IQueryObject<T, string, SQLiteConnection, IDataReader> queryObject)
            :base(queryObject)
        {
        }

        public override string AsQuery()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT COUNT(*)");
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [source]", InnerQueryObject.AsQuery()));

            return queryStringBuilder.ToString();
        }

        new public int Execute()
        {
            string commandText = AsQuery();

            int count;
            IDbConnection connection = ConnectionFactory.CurrentConnection;
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = commandText;

                object result = command.ExecuteScalar();

                count = Convert.ToInt32(result);
            }

            return count;
        }
    }
}
