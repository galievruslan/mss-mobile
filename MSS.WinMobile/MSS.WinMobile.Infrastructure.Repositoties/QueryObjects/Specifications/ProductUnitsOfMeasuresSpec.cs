using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications {
    public class ProductUnitsOfMeasuresSpec  : ISpecification<ProductsUnitOfMeasure> {

        public Product Product { get; private set; }
        public ProductUnitsOfMeasuresSpec(Product product) {
            Product = product;
        }
    }
}

