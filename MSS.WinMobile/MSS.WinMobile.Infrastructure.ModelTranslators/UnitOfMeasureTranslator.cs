using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
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
