using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.UI.Presenters.DataRetrievers
{
    public class RoutePointRetriever : IDataPageRetriever<RoutePoint>
    {
        private readonly Route _route;

        public RoutePointRetriever(Route route)
        {
            _route = route;
        }

        public int Count {
            get { return RoutePoint.GetCountByRoute(_route); }
        }

        public RoutePoint[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return RoutePoint.GetByRoute(_route, lowerPageBoundary, rowsPerPage);
        }
    }
}
