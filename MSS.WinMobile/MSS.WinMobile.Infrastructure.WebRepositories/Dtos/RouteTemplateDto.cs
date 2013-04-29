namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/template_routes.json")]
    public class RouteTemplateDto : Dto
    {
        public int DayOfWeek { get; set; }
    }
}
