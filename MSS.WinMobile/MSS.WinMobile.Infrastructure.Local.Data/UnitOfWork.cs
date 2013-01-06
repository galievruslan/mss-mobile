using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenNETCF.ORM;
using MSS.WinMobile.Infrastructure.Data;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        SqlCeDataStore _store;

        protected UnitOfWork(string storageName)
        {
            _store = new SqlCeDataStore(storageName);
            if (!_store.StoreExists)
            {
                _store.CreateStore();
            }

            _store.DiscoverTypes(System.Reflection.Assembly.GetAssembly(typeof(Customer)));
        }

        #region IUnitOfWork Members

        public ITransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
