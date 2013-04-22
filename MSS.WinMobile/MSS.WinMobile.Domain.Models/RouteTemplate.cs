using System;

namespace MSS.WinMobile.Domain.Models
{
    public class RouteTemplate : Model
    {
        public RouteTemplate(int id, int managerId, DayOfWeek dayOfWeek)
            :base(id)
        {
            ManagerId = managerId;
            DayOfWeek = dayOfWeek;
        }

        public int ManagerId { get; private set; }

        public DayOfWeek DayOfWeek { get; private set; }
    }
}
