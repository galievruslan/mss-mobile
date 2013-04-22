using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class ManagerRepository : Repository<Manager>
    {
        public ManagerRepository(SqliteConnectionFactory connectionFactory, SqliteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<Manager> GetQueryObject()
        {
            return new ManagerQueryObject(ConnectionFactory, new ManagerTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Managers (Id, Name) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(Manager model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM Managers WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Manager model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
