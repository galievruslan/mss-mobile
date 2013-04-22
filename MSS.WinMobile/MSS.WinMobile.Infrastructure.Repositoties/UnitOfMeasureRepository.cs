using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class UnitOfMeasureRepository : Repository<UnitOfMeasure>
    {
        public UnitOfMeasureRepository(SQLiteConnectionFactory connectionFactory, SQLiteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<UnitOfMeasure> GetQueryObject()
        {
            return new UnitOfMeasureQueryObject(ConnectionFactory, new UnitOfMeasureTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO UnitsOfMeasure (Id, Name) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(UnitOfMeasure model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM UnitsOfMeasure WHERE Id = {0}";
        protected override string GetDeleteQueryFor(UnitOfMeasure model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
