using System;
using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Infrastructure.Data;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class SQLiteConnectionFactory : IConnectionFactory<SQLiteConnection>, IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SQLiteConnectionFactory));

        private readonly SQLiteDatabase _sqliteDatabase;
        public SQLiteConnectionFactory(SQLiteDatabase sqliteDatabase)
        {
            _sqliteDatabase = sqliteDatabase;
        }

        private SQLiteConnection _connection;
        public SQLiteConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection =
                    new SQLiteConnection(string.Format("Data Source={0};Version={1};", _sqliteDatabase.DatabaseFullPath,
                                                       _sqliteDatabase.DatabaseVersion));
                Log.Debug("Connection object is null, so new one created");
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
