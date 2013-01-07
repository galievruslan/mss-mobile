using System.Collections.Generic;
using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;
using Mss.WinMobile.Domain.Model;
using OpenNETCF.ORM;

namespace MSS.WinMobile.Infrastructure.Local.Data.Repositories
{
    public class RouteRepository : GenericRepository<Route>
    {
        public RouteRepository(SqlCeDataStore sqlCeDataStore)
            : base(sqlCeDataStore) { }

        public override Route GetById(int id)
        {
            return SqlCeDataStore.Select<Route>(id);
        }

        public override IEnumerable<Route> Find()
        {
            return SqlCeDataStore.Select<Route>();
        }

        public override IEnumerable<Route> Find(ISpecification specification)
        {
            throw new System.NotImplementedException();
        }

        public override void Add(Route entity)
        {
            SqlCeDataStore.Insert(entity);
        }

        public override void Update(Route entity)
        {
            SqlCeDataStore.Update(entity);
        }

        public override void Delete(Route entity)
        {
            SqlCeDataStore.Delete(entity);
        }
    }
}
