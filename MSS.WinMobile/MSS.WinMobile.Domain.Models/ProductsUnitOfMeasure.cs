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

        private Product _product;
        public Product Product
        {
            get { return _product ?? (_product = Product.GetById(ProductId)); }
            private set { _product = value; }
        }

        public int UnitOfMeasureId { get; private set; }

        public bool Base { get; private set; }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var productsUnitOfMeasure = obj as ProductsUnitOfMeasure;
            if (productsUnitOfMeasure != null)
            {
                return productsUnitOfMeasure.Id == Id;
            }

            return false;
        }
    }
}
