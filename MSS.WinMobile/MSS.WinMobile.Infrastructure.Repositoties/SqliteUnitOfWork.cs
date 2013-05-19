using System;
using System.Data;
using MSS.WinMobile.Infrastructure.Storage;
using log4net;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class SqLiteUnitOfWork : IUnitOfWork
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqLiteUnitOfWork));

        private readonly IStorageConnection _connection;
        public SqLiteUnitOfWork(IStorageConnection connection) {
            _connection = connection;
        }

        public bool InTransaction {
            get { return _transaction != null; }
        }

        private IDbTransaction _transaction;
        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
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
                if (_transaction != null)
                    _transaction.Rollback();
            }
            finally
            {
                if (_transaction != null) {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        public void Dispose() {
            if (_transaction != null) {
                try {
                    _transaction.Rollback();
                }
                catch (Exception exception) {
                    Log.Error(exception);
                }
                finally {
                    _transaction.Dispose();
                }
            }
        }
    }
}
