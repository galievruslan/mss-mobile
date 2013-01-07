using System.Collections.Generic;
using Mss.WinMobile.Domain.Model;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>
    {
        public OrderItemRepository(SqlCeDataStore sqlCeDataStore)
            : base(sqlCeDataStore) { }

        public override OrderItem GetById(int id)
        {
            return SqlCeDataStore.Select<OrderItem>(id);
        }

        public override IEnumerable<OrderItem> Find()
        {
            return SqlCeDataStore.Select<OrderItem>();
        }

        public override void Add(OrderItem entity)
        {
            SqlCeDataStore.Insert(entity);
        }

        public override void Update(OrderItem entity)
        {
            SqlCeDataStore.Update(entity);
        }

        public override void Delete(OrderItem entity)
        {
            SqlCeDataStore.Delete(entity);
        }
    }
}
