using System.Collections.Generic;
using Mss.WinMobile.Domain.Model;
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

        public override IEnumerable<RoutePoint> Find()
        {
            return SqlCeDataStore.Select<RoutePoint>();
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
