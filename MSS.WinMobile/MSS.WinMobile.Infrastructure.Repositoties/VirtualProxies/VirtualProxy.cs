using System;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class VirtualProxy<T> where T : IModel
    {
        public VirtualProxy(T model)
        {
            if (model.Id == 0)
                throw new InvalidOperationException("Can't create virtual proxy for not saved (or id - 0) model");
        }
    }
}
