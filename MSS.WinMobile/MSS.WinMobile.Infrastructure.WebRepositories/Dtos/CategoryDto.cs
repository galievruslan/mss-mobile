namespace MSS.WinMobile.Infrastructure.Web.Repositories.Dtos
{
    [Url("synchronization/categories.json")]
    public class CategoryDto : Dto
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}
