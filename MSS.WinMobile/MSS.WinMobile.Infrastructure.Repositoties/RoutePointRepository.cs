using System.Data.SQLite;
using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class RoutePointStorageRepository : SqLiteStorageRepository<RoutePoint> {
        private readonly ISpecificationTranslator<RoutePoint> _specificationTranslator;
        internal RoutePointStorageRepository(IStorage storage, ISpecificationTranslator<RoutePoint> specificationTranslator)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
        }

        protected override QueryObject<RoutePoint> GetQueryObject()
        {
            return new RoutePointQueryObject(Storage, _specificationTranslator, new RoutePointDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO RoutePoints (Id, Route_Id, ShippingAddress_Id, ShippingAddress_Name, Status_Id) VALUES ({0}, {1}, {2}, '{3}', {4})";
        protected override string GetSaveQueryFor(RoutePoint model)
        {
            return string.Format(SaveQueryTemplate, model.Id != 0 ? model.Id.ToString(CultureInfo.InvariantCulture) : "NULL", model.RouteId, model.ShippingAddressId,
                                 model.ShippingAddressName.Replace("'", "''"), model.StatusId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM RoutePoints WHERE Id = {0}";
        protected override string GetDeleteQueryFor(RoutePoint model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
