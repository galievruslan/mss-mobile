using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class RoutePointRetriever : IDataPageRetriever<RoutePoint> {
        private readonly RoutePointRepository _routePointRepository;
        private readonly Route _route;

        public RoutePointRetriever(RoutePointRepository routePointRepository, Route route) {
            _routePointRepository = routePointRepository;
            _route = route;
        }

        public int Count
        {
            get { return _routePointRepository.Find().Where("Route_Id", new Equals(_route.Id)).GetCount(); }
        }

        public RoutePoint[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _routePointRepository.Find().Where("Route_Id", new Equals(_route.Id))
                                     .OrderBy("Id", OrderDirection.Asceding)
                                     .Page(lowerPageBoundary, rowsPerPage)
                                     .ToArray();
        }
    }
}
