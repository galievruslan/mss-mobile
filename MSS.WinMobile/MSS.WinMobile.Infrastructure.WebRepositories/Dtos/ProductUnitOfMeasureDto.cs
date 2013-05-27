namespace MSS.WinMobile.Infrastructure.Web.Repositories.Dtos
{
    [Url("synchronization/product_unit_of_measures.json")]
    public class ProductUnitOfMeasureDto : Dto
    {
        public int ProductId { get; set; }

        public int UnitOfMeasureId { get; set; }

        public double CountInBaseUnit { get; set; }

        public bool Base { get; set; }
    }
}
