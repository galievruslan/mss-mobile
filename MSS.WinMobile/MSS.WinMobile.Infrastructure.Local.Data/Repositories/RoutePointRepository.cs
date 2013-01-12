using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public class RoutePointRepository : GenericRepository<RoutePoint>
    {
        public RoutePointRepository(SqlCeDataStore sqlCeDataStore)
            : base(sqlCeDataStore) { }

        public override RoutePoint GetById(int id)
        {
            return SqlCeDataStore.Select<RoutePoint>(id);
        }

        public override RoutePoint[] Find()
        {
            return SqlCeDataStore.Select<RoutePoint>();
        }

        public override RoutePoint[] Find(Specification<RoutePoint> specification)
        {
            throw new System.NotImplementedException();
        }

        public override void Add(RoutePoint entity)
        {
            SqlCeDataStore.Insert(entity);
        }

        public override void Update(RoutePoint entity)
        {
            SqlCeDataStore.Update(entity);
        }

        public override void Delete(RoutePoint entity)
        {
            SqlCeDataStore.Delete(entity);
        }
    }
}
