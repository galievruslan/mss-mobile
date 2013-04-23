using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class RouteRepository : Repository<Route>
    {
        public RouteRepository(SQLiteConnectionFactory connectionFactory, SQLiteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<Route> GetQueryObject()
        {
            return new RouteQueryObject(ConnectionFactory, new RouteTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Routes (Id, [Date]) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(Route model)
        {
            return string.Format(SaveQueryTemplate, 
                model.Id != 0 ? model.Id.ToString(CultureInfo.InvariantCulture) : "NULL",
                model.Date.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM Routes WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Route model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
