using System;
using System.Collections.Generic;
using System.Text;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Infrastructure.Server
{
    public abstract class GenericRepository<T> where T : Entity
    {
        public abstract T GetById(int id);

        public abstract IEnumerable<T> Find();

        public abstract void Add(T entity);

        public abstract void Update(T entity);

        public abstract void Delete(T entity);
    }
}
