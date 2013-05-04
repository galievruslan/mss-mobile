using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class StatusQueryObject : QueryObject<Status>
    {
        public StatusQueryObject(IStorage storage,
                                 ISpecificationTranslator<Status> specificationTranslator,
                                 DataRecordTranslator<Status> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, Name FROM Statuses";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
