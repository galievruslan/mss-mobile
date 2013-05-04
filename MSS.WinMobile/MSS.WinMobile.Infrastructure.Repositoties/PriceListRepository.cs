using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class PriceListStorageRepository : SqLiteStorageRepository<PriceList> {
        private readonly ISpecificationTranslator<PriceList> _specificationTranslator;
        private readonly IRepositoryFactory _repositoryFactory;
        internal PriceListStorageRepository(IStorage storage, ISpecificationTranslator<PriceList> specificationTranslator, IRepositoryFactory repositoryFactory)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
            _repositoryFactory = repositoryFactory;
        }

        protected override QueryObject<PriceList> GetQueryObject()
        {
            return new PriceListQueryObject(Storage, _specificationTranslator, new PriceListDataRecordTranslator(_repositoryFactory));
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO PriceLists (Id, Name) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(PriceList model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM PriceLists WHERE Id = {0}";
        protected override string GetDeleteQueryFor(PriceList model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
