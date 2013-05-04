using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
{
    public class CustomerTranslator : DtoTranslator<Customer, CustomerDto> {
        private readonly IRepositoryFactory _repositoryFactory;
        public CustomerTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        public override Customer Translate(CustomerDto source) {
            return new CustomerProxy(_repositoryFactory.CreateRepository<ShippingAddress>())
                {
                    Id = source.Id,
                    Name = source.Name
                };
        }
    }
}
