using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specificarions {
    public class ProductPriceWithNameLikeSpec : ISpecification<ProductsPrice> {
        public string Criteria { get; private set; }
        public ProductPriceWithNameLikeSpec(string criteria) {
            Criteria = criteria;
        }
    }
}
