using System;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.Domain.Models
{
    public partial class RouteTemplate
    {
        public RouteTemplate(int id, int managerId, DayOfWeek dayOfWeek)
        {
            Id = id;
            DayOfWeek = dayOfWeek;
            ManagerId = managerId;
        }

        public DayOfWeek DayOfWeek { get; private set; }

        public int ManagerId { get; private set; }

        private Manager _manager;
        public Manager Manager
        {
            get { return _manager ?? (_manager = Manager.GetById(ManagerId)); }
            private set { _manager = value; }
        }

        public QueryObject<RoutePointTemplate> GetPoints()
        {
            return RoutePointTemplate.GetByRouteTemplate(this);
        }

        public Route CreateRoute()
        {
            var route = new Route(Manager);
            route.Save();
            foreach (var routePointTemplate in GetPoints())
            {
                route.AddPoint(routePointTemplate.ShippingAddress);
            }

            return route;
        }
    }
}
