using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
{
    public class RouteTemplateTranslator : DtoTranslator<RouteTemplate, RouteTemplateDto> {
        private readonly IRepositoryFactory _repositoryFactory;
        public RouteTemplateTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        public override RouteTemplate Translate(RouteTemplateDto value)
        {
            var proxy = new RouteTemplateProxy(_repositoryFactory.CreateRepository<RoutePointTemplate>())
                {
                    Id = value.Id,
                    DayOfWeek = (DayOfWeek) value.DayOfWeek
                };
            return proxy;
        }
    }
}
