using OpenNETCF.ORM;
using MSS.WinMobile.Infrastructure.Data;
using Mss.WinMobile.Domain.Model;

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
            if (!store.StoreExists) {
                store.DiscoverTypes(System.Reflection.Assembly.GetAssembly(typeof (Customer)));
                store.CreateStore();
            }
            else {
                store.DiscoverTypes(System.Reflection.Assembly.GetAssembly(typeof(Customer)));
            }

            return new Transaction(store);
        }

        #endregion
    }
}
