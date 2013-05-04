using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class RouteQueryObject : QueryObject<Route>
    {
        public RouteQueryObject(IStorage storage,
                                ISpecificationTranslator<Route> specificationTranslator,
                                DataRecordTranslator<Route> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, [Date] FROM Routes";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
