using System;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Route
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ManagerId { get; set; }

        public RoutePoint[] GetPoints()
        {
            return RoutePoint.GetByRoute(this);
        }
    }
}
