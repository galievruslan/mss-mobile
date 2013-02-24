namespace MSS.WinMobile.Infrastructure.Remote.Data.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UnitOfMeasureDto[] ProductUnitOfMeasures { get; set; }
    }
}
