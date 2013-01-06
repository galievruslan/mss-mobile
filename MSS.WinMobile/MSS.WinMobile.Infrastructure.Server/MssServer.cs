using System;
using System.Collections.Generic;
using System.Text;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Infrastructure.Remote.Data
{
    public class MssServer
    {
        public MssServer(string address, int port) {
            Address = address;
            Port = port;
        }

        public string Address
        {
            get;
            private set;
        }

        public int Port
        {
            get;
            private set;
        }

        public GenericRepository<T> GetRepository<T>() where T : IEntity {
            if (typeof(T) == typeof(Manager)) { 

            }

            throw new RepositoryNotFoundException(typeof(T));
        }
    }

    public class RepositoryNotFoundException : Exception {
        public RepositoryNotFoundException(Type type) 
            :base(string.Format("Can't find repository for {0}", type.Name))
        {
        }
    }
}
