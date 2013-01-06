﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mss.WinMobile.Domain.Model;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(SqlCeDataStore sqlCeDataStore)
            : base(sqlCeDataStore) { }

        public override Order GetById(int id)
        {
            return SqlCeDataStore.Select<Order>(id);
        }

        public override IEnumerable<Order> Find()
        {
            return SqlCeDataStore.Select<Order>();
        }

        public override void Add(Order entity)
        {
            SqlCeDataStore.Insert(entity);
        }

        public override void Update(Order entity)
        {
            SqlCeDataStore.Update(entity);
        }

        public override void Delete(Order entity)
        {
            SqlCeDataStore.Delete(entity);
        }
    }
}
