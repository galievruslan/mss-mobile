using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Remote.Data;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeRoutes : SynchronizationCommand {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeRoutes));

        private readonly Server _server;

        public SynchronizeRoutes(Server server, ISession session)
            :base(session) {
            _server = server;
        }

        protected override bool Execute() {
            var routes = new List<Route>();
            var routesPoints = new List<RoutePoint>();

            var routeDto = _server.RouteService.GetToday();

            var route = new Route
            {
                Id = routeDto.Id,
                Date = routeDto.Date,
                ManagerId = routeDto.ManagerId
            };
            routes.Add(route);

            foreach (var routePointDto in routeDto.RoutePoints)
            {
                var routePoint = new RoutePoint
                {
                    Id = routePointDto.Id,
                    RouteId = routeDto.Id,
                    ShippingAddressId = routePointDto.ShippingAddressId,
                    StatusId = routePointDto.StatusId
                };
                routesPoints.Add(routePoint);
            }

            SynchronizeEntity(routes);
            SynchronizeEntity(routesPoints);
            routes.Clear();
            routesPoints.Clear();

            return true;
        }
    }
}
