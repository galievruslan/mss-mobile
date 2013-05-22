namespace MSS.WinMobile.Domain.Models
{
    public class ProductsPrice : Model
    {
        public int ProductId { get; protected set; }

        public string ProductName { get; protected set; }

        public int ProductCategoryId { get; protected set; }

        public int PriceListId { get; protected set; }

        public decimal Price { get; protected set; }
    }
}
