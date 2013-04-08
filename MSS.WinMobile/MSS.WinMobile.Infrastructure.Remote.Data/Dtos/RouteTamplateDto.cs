﻿namespace MSS.WinMobile.Infrastructure.Server.Dtos
{
    public class RouteTemplateDto
    {
        public RouteTemplateDto()
        {
            RoutePointTemplates = new RoutePointTemplateDto[0];
        }

        public int Id { get; set; }

        public int DatyOfWeek { get; set; }

        public int ManagerId { get; set; }

        public RoutePointTemplateDto[] RoutePointTemplates { get; set; }
    }
}
