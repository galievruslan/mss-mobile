using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
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
