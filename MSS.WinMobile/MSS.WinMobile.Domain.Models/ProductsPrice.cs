namespace MSS.WinMobile.Domain.Models
{
    public class ProductsPrice : Model
    {
        public ProductsPrice(int id, int productId, string productName, int priceListId, decimal price)
            :base(id)
        {
            ProductId = productId;
            ProductName = productName;
            PriceListId = priceListId;
            Price = price;
        }

        public int ProductId { get; private set; }

        public string ProductName { get; private set; }

        public int PriceListId { get; private set; }

        public decimal Price { get; private set; }
    }
}
