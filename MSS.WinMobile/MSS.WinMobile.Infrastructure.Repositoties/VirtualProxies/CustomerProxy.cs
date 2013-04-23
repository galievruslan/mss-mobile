﻿using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class CustomerProxy : Customer
    {
        new public int Id
        {
            get { return base.Id; }
            internal set { base.Id = value; }
        }

        new public string Name
        {
            get { return base.Name; }
            internal set { base.Name = value; }
        }
    }
}
