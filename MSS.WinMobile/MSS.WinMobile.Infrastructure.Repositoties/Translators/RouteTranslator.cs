using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators {
    public class RouteDataRecordTranslator : DataRecordTranslator<Route> {
        private readonly IRepositoryFactory _repositoryFactory;

        public RouteDataRecordTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        protected override Route TranslateOne(IDataRecord value) {
            var proxy = new RouteProxy(_repositoryFactory.CreateRepository<RoutePoint>(),
                                       _repositoryFactory.CreateRepository<Order>())
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Date = value.GetDateTime(value.GetOrdinal("Date"))
                };
            return proxy;
        }
    }
}
