using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class RouteTemplateSQLiteRepository : SQLiteRepository<RouteTemplate>
    {
        public RouteTemplateSQLiteRepository(IConnectionFactory<SQLiteConnection> connectionFactory, SQLiteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<RouteTemplate> GetQueryObject()
        {
            return new RouteTemplateQueryObject(ConnectionFactory, new RouteTemplateDataRecordTranslator());
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
