using OpenNETCF.ORM;
using MSS.WinMobile.Infrastructure.Data;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _storageName;

        public UnitOfWork(string storageName)
        {
            _storageName = storageName;
        }

        #region IUnitOfWork Members

        public ITransaction BeginTransaction()
        {
            var store = new SqlCeDataStore(_storageName);
            if (!store.StoreExists)
            {
                store.DiscoverTypes(System.Reflection.Assembly.GetAssembly(typeof(Customer)));
                store.CreateStore();
            }

            return new Transaction(store);
        }

        #endregion
    }
}
