using System;
using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public sealed class SqliteConnectionFactory
    {
        private static volatile SqliteConnectionFactory _instance;
        private static readonly object SyncRoot = new Object();

        private readonly string _fileName;
        private readonly string _fileVersion;
        private SqliteConnectionFactory(string fileName, string fileVersion)
        {
            _fileName = fileName;
            _fileVersion = fileVersion;
        }

        public static SqliteConnectionFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    var manager = new ConfigurationManager(Environments.AppPath);
                    string fileName = manager.GetConfig("Commom").GetSection("Database").GetSetting("FileName").Value;
                    string fileVersion =
                        manager.GetConfig("Commom").GetSection("Database").GetSetting("FileVersion").Value;

                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new SqliteConnectionFactory(Environments.AppPath + fileName, fileVersion);
                    }
                }

                return _instance;
            }
        }

        private static readonly ILog Log = LogManager.GetLogger(typeof(SqliteConnectionFactory));

        private SQLiteConnection _connection;

        public SQLiteConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SQLiteConnection(string.Format("Data Source={0};Version={1};", _fileName, _fileVersion));
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
