namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    public class ProductDto : Dto
    {
        public ProductDto()
        {
            ProductUnitOfMeasures = new ProductUnitOfMeasure[0];
            ProductPrices = new ProductPriceDto[0];
        }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public ProductUnitOfMeasure[] ProductUnitOfMeasures { get; set; }

        public ProductPriceDto[] ProductPrices { get; set; }
    }
}
