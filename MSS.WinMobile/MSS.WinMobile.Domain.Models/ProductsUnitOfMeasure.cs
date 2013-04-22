namespace MSS.WinMobile.Domain.Models
{
    public class ProductsUnitOfMeasure : Model
    {
        public ProductsUnitOfMeasure(int id, int productId, int unitOfMeasureId, bool isBase)
            :base(id)
        {
            ProductId = productId;
            UnitOfMeasureId = unitOfMeasureId;
            Base = isBase;
        }

        public int ProductId { get; private set; }

        public int UnitOfMeasureId { get; private set; }

        public bool Base { get; private set; }
    }
}
