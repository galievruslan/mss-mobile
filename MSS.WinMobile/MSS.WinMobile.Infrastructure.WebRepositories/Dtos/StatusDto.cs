namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/statuses.json")]
    public class StatusDto : Dto
    {
        public string Name { get; set; }
    }
}
