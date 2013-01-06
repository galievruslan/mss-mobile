using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSS.WinMobile.Infrastructure.Data
{
    public interface ITransaction
    {
        void Commit();

        void Rollback();
    }
}
