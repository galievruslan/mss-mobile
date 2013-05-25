using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specifications {
    public class RoutePointInRouteWithShippingAddress : ISpecification<RoutePoint> {
        public Route Route { get; protected set; }
        public ShippingAddress ShippingAddress { get; protected set; }
        public RoutePointInRouteWithShippingAddress(Route route, ShippingAddress shippingAddress) {
            Route = route;
            ShippingAddress = shippingAddress;
        }
    }
}
