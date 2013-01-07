﻿using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Data;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Mss.WinMobile.Domain.Model.IEntity
    {
        protected SqlCeDataStore SqlCeDataStore;

        protected GenericRepository(SqlCeDataStore sqlCeDataStore)
        {
            SqlCeDataStore = sqlCeDataStore;
        }

        #region IGenericRepository<T> Members

        public abstract T GetById(int id);

        public abstract IEnumerable<T> Find();

        public abstract void Add(T entity);

        public abstract void Update(T entity);

        public abstract void Delete(T entity);

        #endregion
    }
}
