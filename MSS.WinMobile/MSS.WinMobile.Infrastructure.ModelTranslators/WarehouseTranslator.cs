using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
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
