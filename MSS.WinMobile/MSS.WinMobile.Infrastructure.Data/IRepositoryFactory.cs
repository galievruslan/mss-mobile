namespace MSS.WinMobile.Infrastructure.Storage {
    public interface IRepositoryFactory {
        IStorageRepository<TModel> CreateRepository<TModel>()
            where TModel : IModel;
    }
}
