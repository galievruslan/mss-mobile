namespace MSS.WinMobile.Domain.Models
{
    public partial class ProductsUnitOfMeasure
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UnitOfMeasureId { get; set; }

        public bool Base { get; set; }
    }
}
