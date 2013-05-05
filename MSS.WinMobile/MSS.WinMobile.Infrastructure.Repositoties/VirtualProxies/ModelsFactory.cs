using System;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies {
    public class ModelsFactory : IModelsFactory {
        private readonly IRepositoryFactory _repositoryFactory;
        public ModelsFactory(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        public Route CreateRoute(DateTime date) {
            return new RouteProxy(date, _repositoryFactory.CreateRepository<RoutePoint>());
        }

        public Order CreateOrder() {
            return new OrderProxy(_repositoryFactory.CreateRepository<OrderItem>());
        }
    }
}
