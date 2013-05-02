using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class RouteTemplateRepository : SqLiteRepository<RouteTemplate>
    {
        public RouteTemplateRepository(SqLiteUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected override QueryObject<RouteTemplate> GetQueryObject()
        {
            return new RouteTemplateQueryObject(UnitOfWork, new RouteTemplateDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO RouteTemplates (Id, DayOfWeek) VALUES ({0}, {1})";
        protected override string GetSaveQueryFor(RouteTemplate model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.DayOfWeek);
        }

        private const string DeleteQueryTemplate = "DELETE FROM RouteTemplates WHERE Id = {0}";
        protected override string GetDeleteQueryFor(RouteTemplate model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
