using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specifications {
    public class CustomerWithNameLikeSpec : ISpecification<Customer> {
        public string Criteria { get; private set; }
        public CustomerWithNameLikeSpec(string criteria) {
            Criteria = criteria;
        }
    }
}
