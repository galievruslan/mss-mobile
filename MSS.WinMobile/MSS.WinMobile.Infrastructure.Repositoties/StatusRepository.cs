using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties
{
    public class StatusStorageRepository : SqLiteStorageRepository<Status> {
        private readonly ISpecificationTranslator<Status> _specificationTranslator;
        internal StatusStorageRepository(IStorage storage, ISpecificationTranslator<Status> specificationTranslator)
            : base(storage) {
            _specificationTranslator = specificationTranslator;
        }

        protected override QueryObject<Status> GetQueryObject()
        {
            return new StatusQueryObject(Storage, _specificationTranslator, new StatusDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Statuses (Id, Name) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(Status model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM Statuses WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Status model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
