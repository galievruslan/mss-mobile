using System;

using System.Collections.Generic;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Data
{
    public interface IConnectionFactory<T>
    {
        T GetConnection();
    }
}
