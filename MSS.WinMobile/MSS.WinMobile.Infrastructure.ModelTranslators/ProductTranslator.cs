using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
{
    public class ProductTranslator : DtoTranslator<Product, ProductDto>
    {
        public override Product Translate(ProductDto value)
        {
            var proxy = new ProductProxy
                {
                    Id = value.Id,
                    Name = value.Name,
                    CategoryId = value.CategoryId != null ? (int)value.CategoryId : 0
                };
            return proxy;
        }
    }
}
