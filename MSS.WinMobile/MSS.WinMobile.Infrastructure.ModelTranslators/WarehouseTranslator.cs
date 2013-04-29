using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public class WarehouseTranslator : DtoTranslator<Warehouse, WarehouseDto>
    {
        public override Warehouse Translate(WarehouseDto value)
        {
            var proxy = new WarehouseProxy
                {
                    Id = value.Id,
                    Address = value.Address
                };
            return proxy;
        }
    }
}
