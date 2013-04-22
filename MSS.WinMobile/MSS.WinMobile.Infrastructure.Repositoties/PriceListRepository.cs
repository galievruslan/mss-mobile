﻿using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class PriceListRepository : Repository<PriceList>
    {
        public PriceListRepository(SqliteConnectionFactory connectionFactory, SqliteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<PriceList> GetQueryObject()
        {
            return new PriceListQueryObject(ConnectionFactory, new PriceListTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO PriceLists (Id, Name) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(PriceList model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM PriceLists WHERE Id = {0}";
        protected override string GetDeleteQueryFor(PriceList model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
