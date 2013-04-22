using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class RouteTemplateRepository : Repository<RouteTemplate>
    {
        public RouteTemplateRepository(SqliteConnectionFactory connectionFactory, SqliteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<RouteTemplate> GetQueryObject()
        {
            return new RouteTemplateQueryObject(ConnectionFactory, new RouteTemplateTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO RouteTemplates (Id, DayOfWeek, Manager_Id) VALUES ({0}, {1}, {2})";
        protected override string GetSaveQueryFor(RouteTemplate model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.DayOfWeek, model.ManagerId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM RouteTemplates WHERE Id = {0}";
        protected override string GetDeleteQueryFor(RouteTemplate model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
