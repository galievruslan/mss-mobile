using System;
using System.Data.SqlServerCe;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : IEntity
    {
        private readonly SqlCeConnection _sqlCeConnection;

        public GenericRepository(SqlCeConnection sqlCeConnection)
        {
            _sqlCeConnection = sqlCeConnection;
        }

        #region IGenericRepository<T> Members

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T[] Find()
        {
            throw new NotImplementedException();
        }

        public T[] Find(Specification<T> specification)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
