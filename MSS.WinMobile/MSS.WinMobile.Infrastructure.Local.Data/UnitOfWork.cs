using OpenNETCF.ORM;
using MSS.WinMobile.Infrastructure.Data;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly SqlCeDataStore _store;

        public UnitOfWork(string storageName)
        {
            _store = new SqlCeDataStore(storageName);
            if (!_store.StoreExists)
            {
                _store.DiscoverTypes(System.Reflection.Assembly.GetAssembly(typeof(Customer)));
                _store.CreateStore();
            }
        }

        #region IUnitOfWork Members

        public ITransaction BeginTransaction()
        {
            return new Transaction(_store);
        }

        #endregion
    }
}
