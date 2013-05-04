using System;

namespace MSS.WinMobile.Infrastructure.Storage {
    public interface IUnitOfWork : IDisposable {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
