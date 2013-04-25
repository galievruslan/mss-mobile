using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using MSS.WinMobile.Infrastructure.Data;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class SQLiteDatabase : IConnectionFactory<SQLiteConnection>, IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SQLiteDatabase));

        public string ConnectionString { get; private set; }

        public SQLiteDatabase(string databaseFullPath, string databaseVersion, string databaseScriptFullPath)
        {
            ConnectionString = string.Format("Data Source=\"{0}\";Version={1};", databaseFullPath,
                                             databaseVersion);
            if (!File.Exists(databaseFullPath))
            {
                SQLiteConnection.CreateFile(databaseFullPath);
                
                string schemaScript;
                using (StreamReader reader = File.OpenText(databaseScriptFullPath))
                {
                    schemaScript = reader.ReadToEnd();
                }
                
                IDbConnection connection = GetConnection();
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
        }

        public SQLiteDatabase(string databaseScriptFullPath)
        {
            ConnectionString = "Data Source=\":memory:\";Version=3";
            string schemaScript;
            using (StreamReader reader = File.OpenText(databaseScriptFullPath))
            {
                schemaScript = reader.ReadToEnd();
            }

            IDbConnection connection = GetConnection();
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
              
        private SQLiteConnection _connection;
        public SQLiteConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection =
                    new SQLiteConnection(ConnectionString);
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
