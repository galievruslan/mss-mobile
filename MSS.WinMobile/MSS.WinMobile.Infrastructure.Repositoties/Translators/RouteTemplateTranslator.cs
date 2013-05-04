using System;
using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class RouteTemplateDataRecordTranslator : DataRecordTranslator<RouteTemplate>
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public RouteTemplateDataRecordTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        protected override RouteTemplate TranslateOne(IDataRecord value)
        {
            var proxy = new RouteTemplateProxy(_repositoryFactory.CreateRepository<RoutePointTemplate>())
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    DayOfWeek = (DayOfWeek) value.GetInt32(value.GetOrdinal("DayOfWeek"))
                };
            return proxy;
        }
    }
}
