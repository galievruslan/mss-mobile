using System.Data;
using System.Data.SQLite;
using System.IO;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class SqliteDatabase
    {
        private readonly string _databaseFullPath;
        private readonly string _databaseVersion;
        private readonly string _databaseScriptFullPath;

        public SqliteDatabase(string databaseFullPath, string databaseVersion, string databaseScriptFullPath)
        {
            _databaseFullPath = databaseFullPath;
            _databaseVersion = databaseVersion;
            _databaseScriptFullPath = databaseScriptFullPath;

            if (!File.Exists(_databaseFullPath))
            {
                SQLiteConnection.CreateFile(_databaseFullPath);
                IDbConnection connection =
                    new SQLiteConnection(string.Format("Data Source={0};Version={1};", _databaseFullPath,
                                                       _databaseVersion));

                string schemaScript;
                using (StreamReader reader = File.OpenText(_databaseScriptFullPath))
                {
                    schemaScript = reader.ReadToEnd();
                }

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

        public string DatabaseFullPath { get { return _databaseFullPath; } }
        public string DatabaseVersion { get { return _databaseVersion; } }
    }
}
