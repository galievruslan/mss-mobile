using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Infrastructure.Data;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class SqliteConnectionFactory : IConnectionFactory<SQLiteConnection>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqliteConnectionFactory));

        private readonly SqliteDatabase _sqliteDatabase;
        public SqliteConnectionFactory(SqliteDatabase sqliteDatabase)
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
    }
}
