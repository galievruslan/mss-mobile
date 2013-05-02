﻿using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class UnitOfMeasureRepository : SqLiteRepository<UnitOfMeasure>
    {
        public UnitOfMeasureRepository(SqLiteUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected override QueryObject<UnitOfMeasure> GetQueryObject()
        {
            return new UnitOfMeasureQueryObject(UnitOfWork, new UnitOfMeasureDataRecordTranslator());
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
