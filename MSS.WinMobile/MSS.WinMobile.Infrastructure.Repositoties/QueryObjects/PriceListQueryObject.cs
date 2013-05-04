using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class PriceListQueryObject : QueryObject<PriceList>
    {
        public PriceListQueryObject(IStorage storage,
                                    ISpecificationTranslator<PriceList> specificationTranslator,
                                    DataRecordTranslator<PriceList> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, Name FROM PriceLists";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
