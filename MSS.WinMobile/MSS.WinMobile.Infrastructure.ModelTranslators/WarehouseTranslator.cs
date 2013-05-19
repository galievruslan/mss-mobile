using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators {
    public class WarehouseTranslator : DtoTranslator<Warehouse, WarehouseDto> {
        public override Warehouse Translate(WarehouseDto value) {
            var proxy = new WarehouseProxy {
                Id = value.Id,
                Name = value.Name,
                Address = value.Address,
                Default = false
            };
            return proxy;
        }
    }
}
