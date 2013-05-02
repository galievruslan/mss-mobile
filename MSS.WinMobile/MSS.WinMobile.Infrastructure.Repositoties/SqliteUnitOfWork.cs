using System;
using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Infrastructure.Data;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class SqLiteUnitOfWork : IUnitOfWork, IDisposable, IConnectionFactory<SQLiteConnection>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqLiteUnitOfWork));

        private readonly SqLiteDatabase _sqLiteDatabase;
        public SqLiteUnitOfWork(SqLiteDatabase sqLiteDatabase) {
            _sqLiteDatabase = sqLiteDatabase;
        }

        private SQLiteConnection _connection;
        public SQLiteConnection CurrentConnection
        {
            get
            {
                if (_connection == null)
                {
                    _connection =
                        new SQLiteConnection(_sqLiteDatabase.ConnectionString);
                    Log.Debug("Connection object is null, so new one created");
                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public bool InTransaction {
            get { return _transaction != null; }
        }

        private SQLiteTransaction _transaction;
        public void BeginTransaction()
        {
            _transaction = CurrentConnection.BeginTransaction();
        }

        public void Commit()
        {
            try{
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose() {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
