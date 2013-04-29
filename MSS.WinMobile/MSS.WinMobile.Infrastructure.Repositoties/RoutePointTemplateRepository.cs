﻿using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class RoutePointTemplateSQLiteRepository : SQLiteRepository<RoutePointTemplate>
    {
        public RoutePointTemplateSQLiteRepository(IConnectionFactory<SQLiteConnection> connectionFactory, SQLiteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<RoutePointTemplate> GetQueryObject()
        {
            return new RoutePointTemplateQueryObject(ConnectionFactory, new RoutePointTemplateDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO RoutePointTemplates (Id, RouteTemplate_Id, ShippingAddress_Id) VALUES ({0}, {1}, {2})";
        protected override string GetSaveQueryFor(RoutePointTemplate model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.RouteTemplateId, model.ShippingAddressId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM RoutePointTemplates WHERE Id = {0}";
        protected override string GetDeleteQueryFor(RoutePointTemplate model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
