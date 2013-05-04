using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications {
    public class PricesLinesSpec  : ISpecification<ProductsPrice> {

        public PriceList PriceList { get; private set; }
        public PricesLinesSpec(PriceList priceList) {
            PriceList = priceList;
        }
    }
}

