using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public class PriceListTranslator : DtoTranslator<PriceList, PriceListDto>
    {
        public override PriceList Translate(PriceListDto value)
        {
            var proxy = new PriceListProxy
                {
                    Id = value.Id,
                    Name = value.Name
                };
            return proxy;
        }
    }
}
