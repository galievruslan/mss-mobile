﻿using System;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using IEntity = MSS.WinMobile.Infrastructure.Data.Repositories.IEntity;

namespace MSS.WinMobile.Infrastructure.Data
{
    public interface ITransaction : IDisposable
    {
        void Commit();

        void Rollback();

        IGenericRepository<T> Resolve<T>() where T : IEntity;
    }

    public class RepositoryNotResolvedException : Exception
    {
        public RepositoryNotResolvedException(Type type)
            :base(string.Format(@"Repository for type ""{0}"" not resolved!", type))
        {

        }
    }
}
