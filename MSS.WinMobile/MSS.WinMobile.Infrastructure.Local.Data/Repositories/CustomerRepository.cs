using System.Collections.Generic;
using Mss.WinMobile.Domain.Model;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(SqlCeDataStore sqlCeDataStore)
            : base(sqlCeDataStore) { }

        public override Customer GetById(int id)
        {
            return SqlCeDataStore.Select<Customer>(id);
        }

        public override IEnumerable<Customer> Find()
        {
            return SqlCeDataStore.Select<Customer>();
        }

        public override void Add(Customer entity)
        {
            SqlCeDataStore.Insert(entity);
        }

        public override void Update(Customer entity)
        {
            SqlCeDataStore.Update(entity);
        }

        public override void Delete(Customer entity)
        {
            SqlCeDataStore.Delete(entity);
        }
    }
}
