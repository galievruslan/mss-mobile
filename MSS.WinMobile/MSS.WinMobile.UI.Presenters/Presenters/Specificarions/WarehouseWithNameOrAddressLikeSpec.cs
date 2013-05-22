using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specificarions {
    public class WarehouseWithNameOrAddressLikeSpec : ISpecification<Warehouse> {
        public string Criteria { get; private set; }
        public WarehouseWithNameOrAddressLikeSpec(string criteria) {
            Criteria = criteria;
        }
    }
}
