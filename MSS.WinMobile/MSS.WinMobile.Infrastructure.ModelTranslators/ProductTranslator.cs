using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
{
    public class ProductTranslator : DtoTranslator<Product, ProductDto> {
        private readonly IRepositoryFactory _repositoryFactory;
        public ProductTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        public override Product Translate(ProductDto value)
        {
            var proxy = new ProductProxy(_repositoryFactory.CreateRepository<ProductsUnitOfMeasure>())
                {
                    Id = value.Id,
                    Name = value.Name,
                    CategoryId = value.CategoryId != null ? (int)value.CategoryId : 0
                };
            return proxy;
        }
    }
}
