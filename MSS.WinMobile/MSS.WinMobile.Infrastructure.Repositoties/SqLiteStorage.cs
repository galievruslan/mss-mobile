using System;
using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Infrastructure.Storage;
using log4net;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class SqLiteStorage : IStorage {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqLiteStorage));
        
        private readonly string _connectionString;
        public string Path { get; private set; }
        internal SqLiteStorage(string databaseFullPath) {
            Path = databaseFullPath;
            _connectionString = string.Format("Data Source=\"{0}\";Version=3;", Path);
        }

        internal SqLiteStorage() {
            _connectionString = "Data Source=\":memory:\";Version=3";
        }

        private SQLiteConnection _connection;
        public IStorageConnection Connect() {
            if (_connection == null) {
                _connection =
                    new SQLiteConnection(_connectionString);
                Log.Debug("Connection object is null, so new one created");
            }

            if (_connection.State != ConnectionState.Open) {
                _connection.Open();
            }

            return new SqLiteStorageConnection(_connection);
        }

        public void Dispose() {
            if (_connection != null) {
                try {
                    _connection.Close();
                }
                catch (Exception exception) {
                    Log.Error(exception);
                }
                finally {
                    _connection.Dispose();
                }
            }
        }
    }
}
