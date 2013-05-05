namespace MSS.WinMobile.Infrastructure.Storage {
    public interface IUnitOfWorkFactory {
        IUnitOfWork CreateUnitOfWork();
    }
}
