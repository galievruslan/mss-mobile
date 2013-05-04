using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
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
