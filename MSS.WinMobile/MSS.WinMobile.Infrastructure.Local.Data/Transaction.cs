using System.Data.SqlServerCe;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Data.Repositories;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public class Transaction : ITransaction
    {
        private readonly SqlCeConnection _sqlCeConnection;
        private readonly SqlCeTransaction _transaction;

        public Transaction(SqlCeConnection sqlCeConnection)
        {
            _sqlCeConnection = sqlCeConnection;
            _transaction = sqlCeConnection.BeginTransaction();
        }

        #region ITransaction Members

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public IGenericRepository<T> Resolve<T>() where T : IEntity
        {
            return new GenericRepository<T>(_sqlCeConnection);
        }

        #endregion

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
