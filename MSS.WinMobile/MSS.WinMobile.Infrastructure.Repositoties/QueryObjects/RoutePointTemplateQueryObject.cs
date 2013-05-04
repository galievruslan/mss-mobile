﻿using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class RoutePointTemplateQueryObject : QueryObject<RoutePointTemplate>
    {
        public RoutePointTemplateQueryObject(IStorage storage,
                                             ISpecificationTranslator<RoutePointTemplate> specificationTranslator,
                                             DataRecordTranslator<RoutePointTemplate> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery = "SELECT Id, RouteTemplate_Id, ShippingAddress_Id FROM RoutePointTemplates";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
