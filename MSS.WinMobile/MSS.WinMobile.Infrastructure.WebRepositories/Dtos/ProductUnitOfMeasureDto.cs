namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/product_unit_of_measures.json")]
    public class ProductUnitOfMeasure : Dto
    {
        public int ProductId { get; set; }

        public int UnitOfMeasureId { get; set; }

        public bool Base { get; set; }
    }
}
