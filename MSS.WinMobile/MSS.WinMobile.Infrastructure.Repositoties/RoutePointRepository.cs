using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class RoutePointRepository : SqLiteRepository<RoutePoint>
    {
        public RoutePointRepository(SqLiteUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected override QueryObject<RoutePoint> GetQueryObject()
        {
            return new RoutePointQueryObject(UnitOfWork, new RoutePointDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO RoutePoints (Id, Route_Id, ShippingAddress_Id, ShippingAddress_Name, Status_Id) VALUES ({0}, {1}, {2}, '{3}', {4})";
        protected override string GetSaveQueryFor(RoutePoint model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.RouteId, model.ShippingAddressId,
                                 model.ShippingAddressName.Replace("'", "''"), model.StatusId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM RoutePoints WHERE Id = {0}";
        protected override string GetDeleteQueryFor(RoutePoint model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
