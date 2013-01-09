using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using OpenNETCF.ORM;
using IEntity = MSS.WinMobile.Domain.Models.IEntity;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        protected SqlCeDataStore SqlCeDataStore;

        protected GenericRepository(SqlCeDataStore sqlCeDataStore)
        {
            SqlCeDataStore = sqlCeDataStore;
        }

        #region IGenericRepository<T> Members

        public abstract T GetById(int id);

        public abstract IEnumerable<T> Find();
        public abstract IEnumerable<T> Find(Specification<T> specification);

        public abstract void Add(T entity);

        public abstract void Update(T entity);

        public abstract void Delete(T entity);

        #endregion
    }
}
