using System.Data.SQLite;
using MSS.WinMobile.Infrastructure.Data;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class SqLiteUnitOfWork : IUnitOfWork
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqLiteUnitOfWork));

        private readonly IConnectionFactory<SQLiteConnection> _connectionFactory;
        public SqLiteUnitOfWork(IConnectionFactory<SQLiteConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public bool InTransaction {
            get { return _transaction != null; }
        }

        private SQLiteTransaction _transaction;
        public void BeginTransaction()
        {
            _transaction = _connectionFactory.CurrentConnection.BeginTransaction();
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
    }
}
