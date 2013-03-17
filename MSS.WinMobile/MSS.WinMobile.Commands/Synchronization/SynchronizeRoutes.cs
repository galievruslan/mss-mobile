using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Infrastructure.Server;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeRoutes : Command<bool> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeRoutes));

        private readonly Server _server;

        public SynchronizeRoutes(Server server)
        {
            _server = server;
        }

        protected override bool Execute() {
            var routes = new List<Route>();
            var routesPoints = new List<RoutePoint>();

            var routeDto = _server.RouteService.GetToday();

            var route = new Route(routeDto.Id, routeDto.ManagerId, routeDto.Date);
            routes.Add(route);

            foreach (var routePointDto in routeDto.RoutePoints)
            {
                var routePoint = new RoutePoint(routePointDto.Id, routeDto.Id, routePointDto.ShippingAddressId,
                                                routePointDto.StatusId);
                routesPoints.Add(routePoint);
            }

            if (routes.Any())
            {
                ActiveRecordBase.BeginTransaction();
                try
                {
                    foreach (var price in routes)
                    {
                        if (Route.GetById(price.Id) != null)
                            price.Update();
                        else
                            price.Create();
                    }
                    ActiveRecordBase.Commit();
                }
                catch (Exception)
                {
                    ActiveRecordBase.Rollback();
                }
            }

            if (routesPoints.Any())
            {
                ActiveRecordBase.BeginTransaction();
                try
                {
                    foreach (var routePoint in routesPoints)
                    {
                        if (RoutePoint.GetById(routePoint.Id) != null)
                            routePoint.Update();
                        else
                            routePoint.Create();
                    }
                    ActiveRecordBase.Commit();
                }
                catch (Exception)
                {
                    ActiveRecordBase.Rollback();
                }
            }

            routes.Clear();
            routesPoints.Clear();

            return true;
        }
    }
}
