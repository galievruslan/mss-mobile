using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Storage {
    public interface IStorageRepository<TModel> where TModel : IModel {
        TModel GetById(int id);
        IQueryObject<TModel> Find();
        TModel Save(TModel model);
        void Delete(TModel model);
    }
}
