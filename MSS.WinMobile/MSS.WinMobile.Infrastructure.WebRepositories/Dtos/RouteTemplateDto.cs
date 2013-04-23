namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    public class RouteTemplateDto : Dto
    {
        public RouteTemplateDto()
        {
            TemplateRoutePoints = new RoutePointTemplateDto[0];
        }

        public int DatyOfWeek { get; set; }

        public int ManagerId { get; set; }

        public RoutePointTemplateDto[] TemplateRoutePoints { get; set; }
    }
}
