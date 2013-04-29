using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public class ShippingAddressdTranslator : DtoTranslator<ShippingAddress, ShippingAddressDto>
    {
        public override ShippingAddress Translate(ShippingAddressDto value)
        {
            var proxy = new ShippingAddressProxy
                {
                    Id = value.Id,
                    CustomerId = value.CustomerId,
                    Name = value.Name,
                    Address = value.Address,
                };
            return proxy;
        }
    }
}
