using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specifications {
    public class PriceOfProductWithCategorySpec : ISpecification<ProductsPrice> {
        public IEnumerable<int> CategoryIds { get; protected set; }
        public PriceOfProductWithCategorySpec(IEnumerable<int> categoryIds) {
            CategoryIds = categoryIds;
        }
    }
}
