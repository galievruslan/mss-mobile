using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class RoutePointQueryObject : QueryObject<RoutePoint>
    {
        public RoutePointQueryObject(SqliteConnectionFactory connectionFactory, ITranslator<RoutePoint> translator)
            : base(connectionFactory, translator)
        {
        }

        public RoutePointQueryObject(IQueryObject<RoutePoint, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery =
            "SELECT routePoints.Id, routePoints.Route_Id, routePoints.ShippingAddress_Id, shippingAddresses.Name as ShippingAddress_Name, routePoints.Status_Id " +
            "FROM RoutePoints routePoints Left Join " +
            "ShippingAddresses shippingAddresses on routePoints.ShippingAddress_Id = shippingAddresses.Id";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
