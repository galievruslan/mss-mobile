using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
{
    public class StatusTranslator : DtoTranslator<Status, StatusDto>
    {
        public override Status Translate(StatusDto value)
        {
            var proxy = new StatusProxy
                {
                    Id = value.Id,
                    Name = value.Name
                };
            return proxy;
        }
    }
}
