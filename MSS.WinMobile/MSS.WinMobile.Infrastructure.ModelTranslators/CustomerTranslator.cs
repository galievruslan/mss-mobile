using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public class CustomerTranslator : DtoTranslator<Customer, CustomerDto> {
        private readonly ShippingAddressRepository _shippingAddressRepository;
        public CustomerTranslator(ShippingAddressRepository shippingAddressRepository) {
            _shippingAddressRepository = shippingAddressRepository;
        }

        public override Customer Translate(CustomerDto source) {
            return new CustomerProxy(_shippingAddressRepository)
                {
                    Id = source.Id,
                    Name = source.Name
                };
        }
    }
}
