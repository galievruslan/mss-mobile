using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mss.WinMobile.Domain.Model
{
    public class RoutePoint : Entity
    {
        public RoutePoint(int id, Route route, Customer customer, Status status) 
            :base (id)
        {
            Route = route;
            Customer = customer;
            Status = status;
        }

        public Route Route { get; set; }

        public Customer Customer { get; set; }

        public Status Status { get; set; }
    }
}
