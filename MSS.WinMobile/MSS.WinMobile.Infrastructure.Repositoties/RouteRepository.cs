using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class RouteStorageRepository : SqLiteStorageRepository<Route> {
        private readonly ISpecificationTranslator<Route> _specificationTranslator;
        private readonly IRepositoryFactory _repositoryFactory;
        internal RouteStorageRepository(IStorage storage, ISpecificationTranslator<Route> specificationTranslator, IRepositoryFactory repositoryFactory)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
            _repositoryFactory = repositoryFactory;
        }

        protected override QueryObject<Route> GetQueryObject()
        {
            return new RouteQueryObject(Storage, _specificationTranslator, new RouteDataRecordTranslator(_repositoryFactory));
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Routes (Id, [Date]) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(Route model)
        {
            return string.Format(SaveQueryTemplate, 
                model.Id != 0 ? model.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                model.Date.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM Routes WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Route model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
