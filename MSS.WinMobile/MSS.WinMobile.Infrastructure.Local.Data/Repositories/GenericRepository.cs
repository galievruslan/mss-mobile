using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using IEntity = MSS.WinMobile.Domain.Models.IEntity;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        protected readonly SqlCeDataStore SqlCeDataStore;

        protected GenericRepository(SqlCeDataStore sqlCeDataStore)
        {
            SqlCeDataStore = sqlCeDataStore;
        }

        #region IGenericRepository<T> Members

        public abstract T GetById(int id);

        public abstract T[] Find();
        public abstract T[] Find(Specification<T> specification);

        public abstract void Add(T entity);

        public abstract void Update(T entity);

        public abstract void Delete(T entity);

        #endregion
    }
}
