using System.Collections.Generic;
using Mss.WinMobile.Domain.Model;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(SqlCeDataStore sqlCeDataStore)
            : base(sqlCeDataStore) { }

        public override Product GetById(int id)
        {
            return SqlCeDataStore.Select<Product>(id);
        }

        public override IEnumerable<Product> Find()
        {
            return SqlCeDataStore.Select<Product>();
        }

        public override void Add(Product entity)
        {
            SqlCeDataStore.Insert(entity);
        }

        public override void Update(Product entity)
        {
            SqlCeDataStore.Update(entity);
        }

        public override void Delete(Product entity)
        {
            SqlCeDataStore.Delete(entity);
        }
    }
}
