using MSS.WinMobile.Infrastructure.Server.Dtos;

namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    public class ProductDto
    {
        public ProductDto()
        {
            ProductUnitOfMeasures = new ProductUnitOfMeasure[0];
            ProductPrices = new ProductPriceDto[0];
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public ProductUnitOfMeasure[] ProductUnitOfMeasures { get; set; }

        public ProductPriceDto[] ProductPrices { get; set; }
    }
}
