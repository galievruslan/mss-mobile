using System;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Route
    {
        public Route(int id, int managerId, DateTime date)
        {
            Id = id;
            ManagerId = managerId;
            Date = date;
        }

        public DateTime Date { get; private set; }

        public int ManagerId { get; private set; }

        public QueryObject<RoutePoint> GetPoints()
        {
            return RoutePoint.GetByRoute(this);
        }
    }
}
