using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
{
    public class UnitOfMeasureTranslator : DtoTranslator<UnitOfMeasure, UnitOfMeasureDto>
    {
        public override UnitOfMeasure Translate(UnitOfMeasureDto value)
        {
            var proxy = new UnitOfMeasureProxy
                {
                    Id = value.Id,
                    Name = value.Name
                };
            return proxy;
        }
    }
}
