using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class CustomerProxy : Customer {
        private readonly ShippingAddressRepository _shippingAddressRepository;
        public CustomerProxy(ShippingAddressRepository shippingAddressRepository) {
            _shippingAddressRepository = shippingAddressRepository;
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

        public override System.Collections.Generic.IEnumerable<ShippingAddress> ShippingAddresses {
            get { return _shippingAddressRepository.Find().Where("Customer_Id", new Equals(Id)); }
        }
    }
}
