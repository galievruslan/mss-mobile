using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Application.Environment;
using log4net;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public static class ConnectionFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ConnectionFactory));

        private static SQLiteConnection _connection;

        public static SQLiteConnection GetConnection()
        {
            if (_connection == null)
            {
                var manager = new Application.Configuration.ConfigurationManager(Environments.AppPath);
                string fileName = manager.GetConfig("Commom").GetSection("Database").GetSetting("FileName").Value;
                string fileVersion = manager.GetConfig("Commom").GetSection("Database").GetSetting("FileVersion").Value;

                _connection = new SQLiteConnection(string.Format("Data Source={0}\\{1};Version={2};", Environments.AppPath, fileName, fileVersion));
                Log.Debug("Connection object is null, so new one created");
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }
    }
}
