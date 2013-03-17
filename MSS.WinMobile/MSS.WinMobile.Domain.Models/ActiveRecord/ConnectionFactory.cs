using System.Data;
using System.Data.SqlServerCe;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public static class ConnectionFactory
    {
        private static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private static IDbConnection _connection;

        public static IDbConnection GetConnection()
        {
            if (_connection != null)
            {
                return _connection;
            }

            return _connection = new SqlCeConnection(ConnectionString);
        }
    }
}
