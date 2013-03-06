namespace MSS.WinMobile.Domain.Models
{
    public partial class ProductsPrice
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int PriceListId { get; set; }

        public decimal Price { get; set; }
    }
}
