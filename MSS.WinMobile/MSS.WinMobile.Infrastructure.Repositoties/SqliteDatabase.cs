using System.Data;
using System.Data.SQLite;
using System.IO;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class SQLiteDatabase
    {
        public string ConnectionString { get; private set; }

        public SQLiteDatabase(string databaseFullPath, string databaseVersion, string databaseScriptFullPath)
        {
            ConnectionString = string.Format("Data Source={0};Version={1};", databaseFullPath,
                                             databaseVersion);
            if (!File.Exists(databaseFullPath))
            {
                SQLiteConnection.CreateFile(databaseFullPath);
                
                string schemaScript;
                using (StreamReader reader = File.OpenText(databaseScriptFullPath))
                {
                    schemaScript = reader.ReadToEnd();
                }

                using (IDbConnection connection =
                    new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
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
        }

        public SQLiteDatabase(string databaseScriptFullPath)
        {
            ConnectionString = "Data Source=:memory:";
            string schemaScript;
            using (StreamReader reader = File.OpenText(databaseScriptFullPath))
            {
                schemaScript = reader.ReadToEnd();
            }

            using (IDbConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
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
    }
}
