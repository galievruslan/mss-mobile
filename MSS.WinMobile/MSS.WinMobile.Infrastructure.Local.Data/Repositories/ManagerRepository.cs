using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public class ManagerRepository : GenericRepository<Manager>
    {
        public ManagerRepository(SqlCeDataStore sqlCeDataStore)
            : base(sqlCeDataStore) { }

        public override Manager GetById(int id)
        {
            return SqlCeDataStore.Select<Manager>(id);
        }

        public override Manager[] Find()
        {
            return SqlCeDataStore.Select<Manager>();
        }

        public override Manager[] Find(Specification<Manager> specification)
        {
            throw new System.NotImplementedException();
        }

        public override void Add(Manager entity)
        {
            SqlCeDataStore.Insert(entity);
        }

        public override void Update(Manager entity)
        {
            SqlCeDataStore.Update(entity);
        }

        public override void Delete(Manager entity)
        {
            SqlCeDataStore.Delete(entity);
        }
    }
}
