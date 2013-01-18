using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;

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

        public override Customer[] Find()
        {
            return SqlCeDataStore.Select<Customer>();
        }

        public override Customer[] Find(Specification<Customer> specification)
        {            
            throw new System.NotImplementedException();
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
