namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/products.json")]
    public class ProductDto : Dto
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}
