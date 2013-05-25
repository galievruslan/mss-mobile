using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specifications {
    public class PriceListWithNameLikeSpec : ISpecification<PriceList> {
        public string Criteria { get; private set; }
        public PriceListWithNameLikeSpec(string criteria) {
            Criteria = criteria;
        }
    }
}
