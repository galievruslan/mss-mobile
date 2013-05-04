using System;

namespace MSS.WinMobile.Infrastructure.Storage {
    public interface IStorage : IDisposable {
        string Path { get; }
        IStorageConnection Connect();
    }
}
