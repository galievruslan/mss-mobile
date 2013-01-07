using System.Collections.Generic;
using Mss.WinMobile.Domain.Model;
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

        public override IEnumerable<Manager> Find()
        {
            return SqlCeDataStore.Select<Manager>();
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
