namespace MSS.WinMobile.Infrastructure.Remote.Data.Dtos
{
    public class ProductDto
    {
        public ProductDto()
        {
            ProductUnitOfMeasures = new UnitOfMeasureDto[0];
            ProductPrices = new ProductPriceDto[0];
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public UnitOfMeasureDto[] ProductUnitOfMeasures { get; set; }

        public ProductPriceDto[] ProductPrices { get; set; }
    }
}
