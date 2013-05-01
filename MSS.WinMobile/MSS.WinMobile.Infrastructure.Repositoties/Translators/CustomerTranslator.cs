using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class CustomerTranslator : DataRecordTranslator<Customer> {
        private readonly ShippingAddressRepository _shippingAddressRepository;
        public CustomerTranslator(ShippingAddressRepository shippingAddressRepository) {
            _shippingAddressRepository = shippingAddressRepository;
        }

        protected override Customer TranslateOne(IDataRecord value)
        {
            var proxy = new CustomerProxy(_shippingAddressRepository)
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Name = value.GetString(value.GetOrdinal("Name"))
                };
            return proxy;
        }
    }
}
