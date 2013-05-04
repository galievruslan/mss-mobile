namespace MSS.WinMobile.Infrastructure.Storage {
    public interface IStorageManager {
        IStorage CreateOrOpenStorage(string databaseFullPath, string databaseScriptFullPath);
        IStorage InitializeInMemoryStorage(string databaseScriptFullPath);
        void DeleteCurrentStorage();
    }
}
