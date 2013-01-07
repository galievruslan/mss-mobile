using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Infrastructure.Data.Repositories
{
    public interface IGenericRepository<T> where T : IEntity
    {
        T GetById(int id);

        IEnumerable<T> Find();

        IEnumerable<T> Find(Specification<T> specification);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
