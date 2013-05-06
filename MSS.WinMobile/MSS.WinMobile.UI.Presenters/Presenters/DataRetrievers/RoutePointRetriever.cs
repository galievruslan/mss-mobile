using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class RoutePointRetriever : IDataPageRetriever<RoutePoint> {
        private readonly Route _route;

        public RoutePointRetriever(Route route) {
            _route = route;
        }

        public int Count
        {
            get {
                return _route == null ? 0 : _route.Points.Count();
            }
        }

        public RoutePoint[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return _route == null
                       ? new RoutePoint[0]
                       : _route.Points
                               .OrderBy("Id", OrderDirection.Asceding)
                               .Paged(lowerPageBoundary, rowsPerPage)
                               .ToArray();
        }
    }
}
