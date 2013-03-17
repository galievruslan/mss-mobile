namespace MSS.WinMobile.Domain.Models
{
    public partial class ProductsUnitOfMeasure
    {
        public ProductsUnitOfMeasure(int id, int productId, int unitOfMeasureId, bool isBase)
        {
            Id = id;
            ProductId = productId;
            UnitOfMeasureId = unitOfMeasureId;
            Base = isBase;
        }

        public int ProductId { get; private set; }

        public int UnitOfMeasureId { get; private set; }

        public bool Base { get; private set; }
    }
}
