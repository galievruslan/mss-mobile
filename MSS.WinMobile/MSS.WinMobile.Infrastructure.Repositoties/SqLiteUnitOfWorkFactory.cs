using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties {
    public class SqLiteUnitOfWorkFactory : IUnitOfWorkFactory {
        private readonly IStorageManager _storageManager;
        public SqLiteUnitOfWorkFactory(IStorageManager storageManager) {
            _storageManager = storageManager;
        }

        public IUnitOfWork CreateUnitOfWork() {
            return new SqLiteUnitOfWork(_storageManager.Current.Connect());
        }
    }
}
