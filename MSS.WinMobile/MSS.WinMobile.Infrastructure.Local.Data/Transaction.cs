using MSS.WinMobile.Infrastructure.Data;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public class Transaction : ITransaction
    {
        readonly SqlCeDataStore _sqlCeDataStore;

        public Transaction(SqlCeDataStore sqlCeDataStore) {
            _sqlCeDataStore = sqlCeDataStore;
            _sqlCeDataStore.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        #region ITransaction Members

        public void Commit()
        {
            _sqlCeDataStore.Commit();
        }

        public void Rollback()
        {
            _sqlCeDataStore.Rollback();
        }

        #endregion
    }
}
