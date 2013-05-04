using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class RouteTemplateQueryObject : QueryObject<RouteTemplate>
    {
        public RouteTemplateQueryObject(IStorage storage,
                                        ISpecificationTranslator<RouteTemplate> specificationTranslator,
                                        DataRecordTranslator<RouteTemplate> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, DayOfWeek FROM RouteTemplates";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
