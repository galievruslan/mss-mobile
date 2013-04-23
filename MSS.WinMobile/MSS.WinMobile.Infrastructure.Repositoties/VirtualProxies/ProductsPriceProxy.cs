using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class ProductsPriceProxy : ProductsPrice
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetPriceListId(int priceListId)
        {
            PriceListId = priceListId;
        }

        internal void SetProductId(int productId)
        {
            ProductId = productId;
        }

        internal void SetProductName(string productName)
        {
            ProductName = productName;
        }

        internal void SetPrice(decimal price)
        {
            Price = price;
        }
    }
}