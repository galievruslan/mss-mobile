using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;

namespace MSS.WinMobile.Infrastructure.Data.Repositories
{
    public interface IGenericRepository<T> where T : IEntity
    {
        T GetById(int id);

        T[] Find();

        T[] Find(Specification<T> specification);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
