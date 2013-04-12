using System;
using System.Collections.Generic;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Route
    {
        public Route(Manager manager)
        {
            ManagerId = manager.Id;
            Date = DateTime.Today;
        }

        public Route()
        {
            ManagerId = Context.ManagerId;
            Date = DateTime.Today;
        }

        public DateTime Date { get; private set; }

        public int ManagerId { get; private set; }

        private Manager _manager;
        public Manager Manager
        {
            get { return _manager ?? (_manager = Manager.GetById(ManagerId)); }
            private set { _manager = value; }
        }
        
        public QueryObject<RoutePoint> GetPoints()
        {
            return RoutePoint.GetByRoute(this);
        }

        public void AddPoint(ShippingAddress shippingAddress)
        {
            // TODO Change retrieving status by id to retrieving by name in config
            var routePoint = new RoutePoint(this, shippingAddress, Status.GetById(2));
            routePoint.Save();
        }
    }
}
