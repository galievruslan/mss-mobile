using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class RoutePointsOrderRetriever : IDataPageRetriever<Order> {
        private readonly RoutePoint _routePoint;
        public RoutePointsOrderRetriever(RoutePoint routePoint) {
            _routePoint = routePoint;
        }

        public int Count
        {
            get { return _routePoint.Orders.Count(); }
        }

        public Order[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _routePoint.Orders.OrderBy("Id", OrderDirection.Asceding)
                      .Paged(lowerPageBoundary, rowsPerPage)
                      .ToArray();
        }
    }
}