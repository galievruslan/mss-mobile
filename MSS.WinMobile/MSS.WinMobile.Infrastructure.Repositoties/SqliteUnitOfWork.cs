using System.Data.SQLite;
using MSS.WinMobile.Infrastructure.Data;
using log4net;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class SqliteUnitOfWork : IUnitOfWork
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqliteUnitOfWork));

        private readonly SqliteConnectionFactory _sqliteConnectionFactory;
        public SqliteUnitOfWork(SqliteConnectionFactory sqliteConnectionFactory)
        {
            _sqliteConnectionFactory = sqliteConnectionFactory;
        }

        public bool InTransaction {
            get { return _transaction != null; }
        }

        private SQLiteTransaction _transaction;
        public void BeginTransaction()
        {
            _transaction = _sqliteConnectionFactory.GetConnection().BeginTransaction();
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
