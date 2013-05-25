using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specifications {
    public class ShippingAddressWithNameOrAddressLikeSpec : ISpecification<ShippingAddress> {
        public string Criteria { get; private set; }
        public ShippingAddressWithNameOrAddressLikeSpec(string criteria) {
            Criteria = criteria;
        }
    }
}
