using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using MSS.WinMobile.Infrastructure.Data;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class SqLiteDatabase : IConnectionFactory<SQLiteConnection>, IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqLiteDatabase));
        public static SqLiteDatabase CreateOrOpenFileDatabase(string databaseFullPath, string databaseScriptFullPath) {
            var database = new SqLiteDatabase(databaseFullPath);
            if (!File.Exists(databaseFullPath)) {
                SQLiteConnection.CreateFile(databaseFullPath);
                ApplyDatabaseSchema(database, databaseScriptFullPath);
            }
            return database;
        }

        public static SqLiteDatabase CreateInMemoryDatabase(string databaseScriptFullPath) {
            var database = new SqLiteDatabase();
            ApplyDatabaseSchema(database, databaseScriptFullPath);
            return database;
        }

        static void ApplyDatabaseSchema(SqLiteDatabase sqLiteDatabase, string databaseScriptFullPath)
        {
            string schemaScript;
            using (StreamReader reader = File.OpenText(databaseScriptFullPath))
            {
                schemaScript = reader.ReadToEnd();
            }

            IDbConnection connection = sqLiteDatabase.CurrentConnection;
            using (IDbTransaction transaction = connection.BeginTransaction())
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = schemaScript;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }

        private readonly string _databaseFullPath;
        private SqLiteDatabase(string databaseFullPath) {
            _databaseFullPath = databaseFullPath;
            ConnectionString = string.Format("Data Source=\"{0}\";Version=3;", _databaseFullPath);
        }

        private SqLiteDatabase() {
            ConnectionString = "Data Source=\":memory:\";Version=3";
        }

        private string ConnectionString { get; set; }

        private SQLiteConnection _connection;
        public SQLiteConnection CurrentConnection
        {
            get {
                if (_connection == null) {
                    _connection =
                        new SQLiteConnection(ConnectionString);
                    Log.Debug("Connection object is null, so new one created");
                }

                if (_connection.State != ConnectionState.Open) {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public void Delete() {
            // If it's in memory database - it'll be deleted after connection disposing
            CurrentConnection.Dispose();
            
            // File database
            if (!string.IsNullOrEmpty(_databaseFullPath)) {
                if (File.Exists(_databaseFullPath))
                    File.Delete(_databaseFullPath);
            }
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
