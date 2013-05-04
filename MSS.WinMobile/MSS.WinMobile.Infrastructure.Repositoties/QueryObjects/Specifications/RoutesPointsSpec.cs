using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications {
    public class RoutesPointsSpec : ISpecification<RoutePoint> {

        public Route Route { get; private set; }
        public RoutesPointsSpec(Route route) {
            Route = route;
        }
    }
}
