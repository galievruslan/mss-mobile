using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
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
