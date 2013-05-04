using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class RouteTemplateProxy : RouteTemplate
    {
        private readonly IStorageRepository<RoutePointTemplate> _routesPointsTemplatesRepository;
        public RouteTemplateProxy(IStorageRepository<RoutePointTemplate> routesPointsTemplatesRepository) {
            _routesPointsTemplatesRepository = routesPointsTemplatesRepository;
        }

        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public DayOfWeek DayOfWeek
        {
            get { return base.DayOfWeek; }
            set { base.DayOfWeek = value; }
        }

        public override IQueryObject<RoutePointTemplate> PointTemplates {
            get {
                var routeTemplatesPointsSpec = new RouteTemplatesPointsSpec(this);
                return _routesPointsTemplatesRepository.Find().Where(routeTemplatesPointsSpec);
            }
        }
    }
}