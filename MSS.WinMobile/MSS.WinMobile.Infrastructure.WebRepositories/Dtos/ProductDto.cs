namespace MSS.WinMobile.Infrastructure.Web.Repositories.Dtos
{
    [Url("synchronization/products.json")]
    public class ProductDto : Dto
    {
        public string Name { get; set; }

        public int? CategoryId { get; set; }
    }
}
