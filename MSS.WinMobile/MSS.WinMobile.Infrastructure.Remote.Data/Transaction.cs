using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Remote.Data.Repositories;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class Transaction : ITransaction
    {
        private readonly RequestDispatcher _requestDispatcher;

        public Transaction(RequestDispatcher requestDispatcher)
        {
            _requestDispatcher = requestDispatcher;
        }

        public void Commit()
        {
            _requestDispatcher.ExecuteRequestPool();
        }

        public void Rollback()
        {
            _requestDispatcher.ClearRequestPool();
        }

        public IGenericRepository<T> Resolve<T>() where T : IEntity
        {
            return new GenericRepository<T>(_requestDispatcher);
        }

        public void Dispose()
        {
            _requestDispatcher.ClearRequestPool();
        }
    }
}
