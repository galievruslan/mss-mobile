using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class CustomerProxy : Customer {
        private readonly IStorageRepository<ShippingAddress> _shippingAddressStorageRepository;
        public CustomerProxy(IStorageRepository<ShippingAddress> shippingAddressStorageRepository) {
            _shippingAddressStorageRepository = shippingAddressStorageRepository;
        }

        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        new public string Address
        {
            get { return base.Address; }
            set { base.Address = value; }
        }

        public override IQueryObject<ShippingAddress> ShippingAddresses {
            get {
                var customersShippingAddressesSpec = new CustomersShippingAddressesSpec(this);
                return _shippingAddressStorageRepository.Find().Where(customersShippingAddressesSpec);
            }
        }
    }
}
