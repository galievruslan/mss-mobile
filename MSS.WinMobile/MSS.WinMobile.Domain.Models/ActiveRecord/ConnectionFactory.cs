using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using log4net;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public static class ConnectionFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ConnectionFactory));

        private static readonly string FileName = ConfigurationManager.AppSettings["DbFileName"];
        private static readonly string FileVersion = ConfigurationManager.AppSettings["DbFileVersion"];
        private static IDbConnection _connection;

        public static IDbConnection GetConnection()
        {
            Log.Debug("Connection object requested");
            if (_connection == null)
            {
                _connection = new SQLiteConnection(string.Format("Data Source={0}\\{1};Version={2};", Context.GetAppPath(), FileName, FileVersion));
                Log.Debug("Connection object is null, so new one created");
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
                Log.Debug("Connection object closed, so we open them");
            }

            Log.Debug("Connection object returned");
            return _connection;
        }
    }
}
