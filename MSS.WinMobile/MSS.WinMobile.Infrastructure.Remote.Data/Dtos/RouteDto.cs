using System;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Dtos
{
    public class RouteDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ManagerId { get; set; }

        public RoutePointDto[] RoutePoints { get; set; }
    }
}
