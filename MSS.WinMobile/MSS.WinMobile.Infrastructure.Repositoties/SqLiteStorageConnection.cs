using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties {
    public class SqLiteStorageConnection : IStorageConnection {
        private readonly SQLiteConnection _sqLiteConnection;
        public SqLiteStorageConnection(SQLiteConnection sqLiteConnection) {
            _sqLiteConnection = sqLiteConnection;
        }

        public void Dispose() {
            _sqLiteConnection.Dispose();
        }

        public IDbTransaction BeginTransaction() {
            return _sqLiteConnection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il) {
            return _sqLiteConnection.BeginTransaction(il);
        }

        public void Close() {
            _sqLiteConnection.Close();
        }

        public void ChangeDatabase(string databaseName) {
            _sqLiteConnection.ChangeDatabase(databaseName);
        }

        public IDbCommand CreateCommand() {
            return _sqLiteConnection.CreateCommand();
        }

        public void Open() {
            _sqLiteConnection.Open();
        }

        public string ConnectionString {
            get { return _sqLiteConnection.ConnectionString; }
            set { _sqLiteConnection.ConnectionString = value; }
        }
        public int ConnectionTimeout {
            get { return _sqLiteConnection.ConnectionTimeout; }
        }
        public string Database {
            get { return _sqLiteConnection.Database; }
        }
        public ConnectionState State {
            get { return _sqLiteConnection.State; }
        }
        public long LastInsertRowId {
            get { return _sqLiteConnection.LastInsertRowId; }
        }
    }
}
