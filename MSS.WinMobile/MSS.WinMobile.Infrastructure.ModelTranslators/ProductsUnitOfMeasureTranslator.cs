using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public class ProductsUnitOfMeasureTranslator : DtoTranslator<ProductsUnitOfMeasure, ProductUnitOfMeasureDto>
    {
        public override ProductsUnitOfMeasure Translate(ProductUnitOfMeasureDto value)
        {
            var proxy = new ProductsUnitOfMeasureProxy
                {
                    Id = value.Id,
                    ProductId = value.ProductId,
                    UnitOfMeasureId = value.UnitOfMeasureId,
                    Base = value.Base
                };
            return proxy;
        }
    }
}
