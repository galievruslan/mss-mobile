using System.Data;

namespace MSS.WinMobile.Infrastructure.Storage {
    public interface IStorageConnection : IDbConnection {
        long LastInsertRowId { get; }
    }
}
