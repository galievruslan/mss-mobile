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
        private readonly IRepositoryFactory _repositoryFactory;
        internal RoutePointStorageRepository(IStorage storage, ISpecificationTranslator<RoutePoint> specificationTranslator, IRepositoryFactory repositoryFactory)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
            _repositoryFactory = repositoryFactory;
        }

        protected override QueryObject<RoutePoint> GetQueryObject()
        {
            return new RoutePointQueryObject(Storage, _specificationTranslator, new RoutePointTranslator(_repositoryFactory));
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO RoutePoints (Id, Route_Id, ShippingAddress_Id, ShippingAddress_Name, ShippingAddress_Address, Status_Id, Synchronized) VALUES ({0}, {1}, {2}, '{3}', '{4}', {5}, {6})";
        protected override string GetSaveQueryFor(RoutePoint model)
        {
            return string.Format(SaveQueryTemplate, model.Id != 0 ? model.Id.ToString(CultureInfo.InvariantCulture) : "NULL", model.RouteId, model.ShippingAddressId,
                                 model.ShippingAddressName.Replace("'", "''"), model.ShippingAddressAddress.Replace("'", "''"), model.StatusId, model.Synchronized ? 1 : 0);
        }

        private const string DeleteQueryTemplate = "DELETE FROM RoutePoints WHERE Id = {0}";
        protected override string GetDeleteQueryFor(RoutePoint model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
