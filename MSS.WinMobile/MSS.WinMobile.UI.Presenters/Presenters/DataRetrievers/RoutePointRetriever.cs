using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class RoutePointRetriever : IDataPageRetriever<RoutePoint>
    {
        private readonly Route _route;

        public RoutePointRetriever(Route route)
        {
            _route = route;
        }

        public int Count
        {
            get { return _route.GetPoints().Count(); }
        }

        public RoutePoint[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                _route.GetPoints()
                      .OrderBy(Route.Table.Fields.ID, OrderDirection.Asceding)
                      .Skip(lowerPageBoundary)
                      .Take(rowsPerPage)
                      .ToArray();
        }
    }
}
