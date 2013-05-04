﻿using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class ProductProxy : Product
    {
        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        new public int CategoryId
        {
            get { return base.CategoryId; }
            set { base.CategoryId = value; }
        }
    }
}
