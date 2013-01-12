using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public class StatusRepository : GenericRepository<Status>
    {
        public StatusRepository(SqlCeDataStore sqlCeDataStore)
            : base(sqlCeDataStore) { }

        public override Status GetById(int id)
        {
            return SqlCeDataStore.Select<Status>(id);
        }

        public override Status[] Find()
        {
            return SqlCeDataStore.Select<Status>();
        }

        public override Status[] Find(Specification<Status> specification)
        {
            throw new System.NotImplementedException();
        }

        public override void Add(Status entity)
        {
            SqlCeDataStore.Insert(entity);
        }

        public override void Update(Status entity)
        {
            SqlCeDataStore.Update(entity);
        }

        public override void Delete(Status entity)
        {
            SqlCeDataStore.Delete(entity);
        }
    }
}
