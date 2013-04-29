using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.WebRepositories.Dtos;

namespace MSS.WinMobile.Infrastructure.ModelTranslators
{
    public class RouteTemplateTranslator : DtoTranslator<RouteTemplate, RouteTemplateDto>
    {
        public override RouteTemplate Translate(RouteTemplateDto value)
        {
            var proxy = new RouteTemplateProxy
                {
                    Id = value.Id,
                    DayOfWeek = (DayOfWeek) value.DayOfWeek
                };
            return proxy;
        }
    }
}
