using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class UnitOfMeasureQueryObject : QueryObject<UnitOfMeasure>
    {
        public UnitOfMeasureQueryObject(IStorage storage,
                                        ISpecificationTranslator<UnitOfMeasure> specificationTranslator,
                                        DataRecordTranslator<UnitOfMeasure> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, Name FROM UnitsOfMeasure";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
