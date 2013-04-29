using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public class CustomerTranslator : DtoTranslator<Customer, CustomerDto>
    {
        public override Customer Translate(CustomerDto source)
        {
            return new CustomerProxy
            {
                Id = source.Id,
                Name = source.Name
            };
        }
    }
}
