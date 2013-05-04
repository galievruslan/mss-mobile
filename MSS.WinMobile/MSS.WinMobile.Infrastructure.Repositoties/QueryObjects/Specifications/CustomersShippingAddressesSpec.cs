using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications {
    public class CustomersShippingAddressesSpec : ISpecification<ShippingAddress> {

        public Customer Customer { get; private set; }
        public CustomersShippingAddressesSpec(Customer customer) {
            Customer = customer;
        }
    }
}
