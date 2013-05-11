using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications {
    public class RoutePointsOrdersSpec : ISpecification<Order> {

        public RoutePoint RoutePoint { get; private set; }
        public RoutePointsOrdersSpec(RoutePoint routePoint) {
            RoutePoint = routePoint;
        }
    }
}
