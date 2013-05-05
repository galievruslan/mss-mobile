using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class RoutePointQueryObject : QueryObject<RoutePoint>
    {
        public RoutePointQueryObject(IStorage storage,
                                     ISpecificationTranslator<RoutePoint> specificationTranslator,
                                     DataRecordTranslator<RoutePoint> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery =
            "SELECT routePoints.Id, routePoints.Route_Id, routePoints.ShippingAddress_Id, routePoints.ShippingAddress_Name, routePoints.Status_Id " +
            "FROM RoutePoints routePoints";
            //"SELECT routePoints.Id, routePoints.Route_Id, routePoints.ShippingAddress_Id, shippingAddresses.Name as ShippingAddress_Name, routePoints.Status_Id " +
            //"FROM RoutePoints routePoints Left Join " +
            //"ShippingAddresses shippingAddresses on routePoints.ShippingAddress_Id = shippingAddresses.Id";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
