using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Data.Repositories;
using OpenNETCF.ORM;
using IEntity = MSS.WinMobile.Domain.Models.IEntity;

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

        public IGenericRepository<T> Resolve<T>() where T : IEntity
        {
            IGenericRepository<T> repository;
            if (typeof (T) == typeof (Customer))
            {
                repository = (IGenericRepository<T>)new CustomerRepository(_sqlCeDataStore);
            }
            else if (typeof (T) == typeof (Manager))
            {
                repository = (IGenericRepository<T>)new ManagerRepository(_sqlCeDataStore);
            }
            else if (typeof(T) == typeof(Order))
            {
                repository = (IGenericRepository<T>)new OrderRepository(_sqlCeDataStore);
            }
            else if (typeof(T) == typeof(OrderItem))
            {
                repository = (IGenericRepository<T>)new OrderItemRepository(_sqlCeDataStore);
            }
            else if (typeof(T) == typeof(Product))
            {
                repository = (IGenericRepository<T>)new ProductRepository(_sqlCeDataStore);
            }
            else if (typeof(T) == typeof(Route))
            {
                repository = (IGenericRepository<T>)new RouteRepository(_sqlCeDataStore);
            }
            else if (typeof(T) == typeof(RoutePoint))
            {
                repository = (IGenericRepository<T>)new RoutePointRepository(_sqlCeDataStore);
            }
            else if (typeof(T) == typeof(Status))
            {
                repository = (IGenericRepository<T>)new StatusRepository(_sqlCeDataStore);
            }
            else
            {
                throw new RepositoryNotResolvedException(typeof(T));
            }

            return repository;
        }

        #endregion

        public void Dispose()
        {
            _sqlCeDataStore.Dispose();
        }
    }
}
