using System;

namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/routes.json")]
    public class RouteDto : Dto
    {
        public RouteDto()
        {
            RoutePoints = new RoutePointDto[0];
        }

        public DateTime Date { get; set; }

        public int ManagerId { get; set; }

        public RoutePointDto[] RoutePoints { get; set; }
    }
}
