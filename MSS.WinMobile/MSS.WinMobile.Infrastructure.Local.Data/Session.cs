using OpenNETCF.ORM;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public class Session : ISession
    {
        private readonly string _storageName;

        public Session(string storageName)
        {
            _storageName = storageName;
        }

        #region IUnitOfWork Members

        public ITransaction BeginTransaction()
        {
            var store = new SqlCeDataStore(_storageName);
            store.DiscoverTypes(System.Reflection.Assembly.LoadFrom("MSS.WinMobile.Domain.Models.dll"));
            if (!store.StoreExists) {
                store.CreateStore();
            }

            return new Transaction(store);
        }

        #endregion
    }
}
