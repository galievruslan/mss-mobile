using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class RoutePointTemplateStorageRepository : SqLiteStorageRepository<RoutePointTemplate> {
        private readonly ISpecificationTranslator<RoutePointTemplate> _specificationTranslator;
        internal RoutePointTemplateStorageRepository(IStorage storage, ISpecificationTranslator<RoutePointTemplate> specificationTranslator)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
        }

        protected override QueryObject<RoutePointTemplate> GetQueryObject()
        {
            return new RoutePointTemplateQueryObject(Storage, _specificationTranslator, new RoutePointTemplateDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO RoutePointTemplates (Id, RouteTemplate_Id, ShippingAddress_Id) VALUES ({0}, {1}, {2})";
        protected override string GetSaveQueryFor(RoutePointTemplate model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.RouteTemplateId, model.ShippingAddressId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM RoutePointTemplates WHERE Id = {0}";
        protected override string GetDeleteQueryFor(RoutePointTemplate model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
