using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class RouteTemplateStorageRepository : SqLiteStorageRepository<RouteTemplate> {
        private readonly ISpecificationTranslator<RouteTemplate> _specificationTranslator;
        private readonly IRepositoryFactory _repositoryFactory;
        internal RouteTemplateStorageRepository(IStorage storage, ISpecificationTranslator<RouteTemplate> specificationTranslator, IRepositoryFactory repositoryFactory)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
            _repositoryFactory = repositoryFactory;
        }

        protected override QueryObject<RouteTemplate> GetQueryObject()
        {
            return new RouteTemplateQueryObject(Storage, _specificationTranslator, new RouteTemplateDataRecordTranslator(_repositoryFactory));
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO RouteTemplates (Id, DayOfWeek) VALUES ({0}, {1})";
        protected override string GetSaveQueryFor(RouteTemplate model)
        {
            return string.Format(SaveQueryTemplate, model.Id, (int)model.DayOfWeek);
        }

        private const string DeleteQueryTemplate = "DELETE FROM RouteTemplates WHERE Id = {0}";
        protected override string GetDeleteQueryFor(RouteTemplate model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
