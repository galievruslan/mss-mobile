using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using MSS.WinMobile.Infrastructure.Storage;
using log4net;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties {
    public class SqLiteStorageManager : IStorageManager {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqLiteStorageManager));

        private SqLiteStorage _currentStorage;
        public IStorage CreateOrOpenStorage(string databaseFullPath, string databaseScriptFullPath) {
            _currentStorage = new SqLiteStorage(databaseFullPath);
            if (!File.Exists(databaseFullPath)) {
                SQLiteConnection.CreateFile(databaseFullPath);
                ApplyDatabaseSchema(_currentStorage, databaseScriptFullPath);
            }
            return _currentStorage;
        }

        public IStorage InitializeInMemoryStorage(string databaseScriptFullPath) {
            _currentStorage = new SqLiteStorage();
            ApplyDatabaseSchema(_currentStorage, databaseScriptFullPath);
            return _currentStorage;
        }

        public void DeleteCurrentStorage() {
            IStorageConnection connection = _currentStorage.Connect();
            try {
                connection.Close();
            }
            catch (Exception exception) {
                Log.Error(exception);
            }
            finally {
                connection.Dispose();
            }

            // File database
            if (!string.IsNullOrEmpty(_currentStorage.Path)) {
                if (File.Exists(_currentStorage.Path))
                    File.Delete(_currentStorage.Path);
            }
        }

        private void ApplyDatabaseSchema(SqLiteStorage sqLiteStorage,
                                                string databaseScriptFullPath) {
            string schemaScript;
            using (StreamReader reader = File.OpenText(databaseScriptFullPath)) {
                schemaScript = reader.ReadToEnd();
            }

            IDbConnection connection = sqLiteStorage.Connect();
            using (var unitOfWork = new SqLiteUnitOfWork(sqLiteStorage)) {
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
