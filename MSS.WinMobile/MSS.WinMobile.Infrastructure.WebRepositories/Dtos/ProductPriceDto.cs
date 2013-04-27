namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/product_prices.json")]
    public class ProductPriceDto : Dto
    {
        public int ProductId { get; set; }

        public int PriceListId { get; set; }

        public decimal Price { get; set; }
    }
}
