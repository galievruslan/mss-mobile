namespace MSS.WinMobile.Domain.Models
{
    public class ProductsUnitOfMeasure : Model
    {
        public int ProductId { get; protected set; }

        public int UnitOfMeasureId { get; protected set; }

        public bool Base { get; protected set; }
    }
}
