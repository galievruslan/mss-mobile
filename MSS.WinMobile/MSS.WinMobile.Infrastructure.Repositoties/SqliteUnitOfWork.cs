using System;
using System.Data;
using MSS.WinMobile.Infrastructure.Storage;
using log4net;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class SqLiteUnitOfWork : IUnitOfWork, IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqLiteUnitOfWork));

        private readonly IStorage _storage;
        public SqLiteUnitOfWork(IStorage storage) {
            _storage = storage;
        }

        public bool InTransaction {
            get { return _transaction != null; }
        }

        private IDbTransaction _transaction;
        public void BeginTransaction()
        {
            _transaction = _storage.Connect().BeginTransaction();
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
