using System;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Server.Dtos
{
    public class RouteDto
    {
        public RouteDto()
        {
            RoutePoints = new RoutePointDto[0];
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ManagerId { get; set; }

        public RoutePointDto[] RoutePoints { get; set; }
    }
}
