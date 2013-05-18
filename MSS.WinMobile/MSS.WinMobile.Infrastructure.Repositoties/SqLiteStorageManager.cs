using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using MSS.WinMobile.Infrastructure.Storage;
using log4net;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties {
    public class SqLiteStorageManager : IStorageManager {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqLiteStorageManager));
        public IStorage CreateOrOpenStorage(string databaseFullPath, string databaseScriptFullPath) {
            Current = new SqLiteStorage(databaseFullPath);
            if (!File.Exists(databaseFullPath)) {
                SQLiteConnection.CreateFile(databaseFullPath);
                ApplyDatabaseSchema(Current, databaseScriptFullPath);
            }
            return Current;
        }

        public IStorage InitializeInMemoryStorage(string databaseScriptFullPath) {
            Current = new SqLiteStorage();
            ApplyDatabaseSchema(Current, databaseScriptFullPath);
            return Current;
        }

        public IStorage Current { get; private set; }

        public void DeleteCurrentStorage() {
            lock (Current) {
                string path = Current.Path;
                try {
                    Current.Dispose();
                }
                catch (Exception exception) {
                    Log.Error(exception);
                }

                // File database
                if (!string.IsNullOrEmpty(path)) {
                    if (File.Exists(path))
                        File.Delete(path);
                }
            }
        }

        private void ApplyDatabaseSchema(IStorage storage,
                                                string databaseScriptFullPath) {
            string schemaScript;
            using (StreamReader reader = File.OpenText(databaseScriptFullPath)) {
                schemaScript = reader.ReadToEnd();
            }

            IDbConnection connection = storage.Connect();
            using (var unitOfWork = new SqLiteUnitOfWork(storage.Connect())) {
                unitOfWork.BeginTransaction();
                using (IDbCommand command = connection.CreateCommand()) {
                    command.CommandText = schemaScript;
                    command.ExecuteNonQuery();
                }
                unitOfWork.Commit();
            }
        }
    }
}
