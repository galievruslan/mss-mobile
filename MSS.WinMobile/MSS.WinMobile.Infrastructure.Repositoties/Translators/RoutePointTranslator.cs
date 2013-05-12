using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class RoutePointTranslator : DataRecordTranslator<RoutePoint> {
        private readonly IRepositoryFactory _repositoryFactory;
        public RoutePointTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        protected override RoutePoint TranslateOne(IDataRecord value)
        {
            var proxy = new RoutePointProxy(_repositoryFactory.CreateRepository<Order>(), _repositoryFactory.CreateRepository<OrderItem>())
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    RouteId = value.GetInt32(value.GetOrdinal("Route_Id")),
                    ShippingAddressId = value.GetInt32(value.GetOrdinal("ShippingAddress_Id")),
                    ShippingAddressName = value.GetString(value.GetOrdinal("ShippingAddress_Name")),
                    StatusId = value.GetInt32(value.GetOrdinal("Status_Id")),
                    Synchronized = value.GetBoolean(value.GetOrdinal("Synchronized"))
                };
            return proxy;
        }
    }
}
