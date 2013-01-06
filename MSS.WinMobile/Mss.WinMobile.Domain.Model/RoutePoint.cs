using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mss.WinMobile.Domain.Model
{
    public class RoutePoint : IEntity
    {
        public int Id { get; set; }

        public Route Route { get; set; }

        public Customer Customer { get; set; }

        public Status Status { get; set; }
    }
}
