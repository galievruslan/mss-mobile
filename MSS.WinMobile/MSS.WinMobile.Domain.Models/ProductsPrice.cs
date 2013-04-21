namespace MSS.WinMobile.Domain.Models
{
    public partial class ProductsPrice
    {
        public ProductsPrice(int id, int productId, int priceListId, decimal price)
        {
            Id = id;
            ProductId = productId;
            PriceListId = priceListId;
            Price = price;
        }

        public int ProductId { get; private set; }

        private Product _product;

        public Product Product
        {
            get { return _product ?? (_product = Product.GetById(ProductId)); }
            private set { _product = value; }
        }

        public int PriceListId { get; private set; }

        public decimal Price { get; private set; }
    }
}
