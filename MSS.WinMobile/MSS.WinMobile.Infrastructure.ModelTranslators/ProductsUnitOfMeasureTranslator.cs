using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
{
    public class ProductsUnitOfMeasureTranslator : DtoTranslator<ProductsUnitOfMeasure, ProductUnitOfMeasureDto>
    {
        public override ProductsUnitOfMeasure Translate(ProductUnitOfMeasureDto value) {
            var proxy = new ProductsUnitOfMeasureProxy {
                Id = value.Id,
                ProductId = value.ProductId,
                UnitOfMeasureId = value.UnitOfMeasureId,
                CountInBaseUnit = (float)value.CountInBaseUnit,
                Base = value.Base
            };
            return proxy;
        }
    }
}
