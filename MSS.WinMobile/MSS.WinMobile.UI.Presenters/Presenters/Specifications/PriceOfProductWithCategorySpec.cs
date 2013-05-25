using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specifications {
    public class PriceOfProductWithCategorySpec : ISpecification<ProductsPrice> {
        public Category Category { get; protected set; }
        public PriceOfProductWithCategorySpec(Category category) {
            Category = category;
        }
    }
}
