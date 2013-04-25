using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class StatusRepository : Repository<Status>
    {
        public StatusRepository(IConnectionFactory<SQLiteConnection> connectionFactory, SQLiteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<Status> GetQueryObject()
        {
            return new StatusQueryObject(ConnectionFactory, new StatusTranslator());
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
