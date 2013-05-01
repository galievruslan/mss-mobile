namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/categories.json")]
    public class CategoryDto : Dto
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}
