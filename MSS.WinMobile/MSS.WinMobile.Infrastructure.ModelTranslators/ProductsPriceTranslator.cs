using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public class ProductsPriceTranslator : DtoTranslator<ProductsPrice, ProductPriceDto>
    {
        public override ProductsPrice Translate(ProductPriceDto value)
        {
            var proxy = new ProductsPriceProxy
                {
                    Id = value.Id,
                    ProductId = value.ProductId,
                    PriceListId = value.PriceListId,
                    Price = value.Price
                };
            return proxy;
        }
    }
}
