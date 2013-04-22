﻿using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class ProductsUnitOfMeasureQueryObject : QueryObject<ProductsUnitOfMeasure>
    {
        public ProductsUnitOfMeasureQueryObject(SqliteConnectionFactory connectionFactory, ITranslator<ProductsUnitOfMeasure> translator)
            : base(connectionFactory, translator)
        {
        }

        public ProductsUnitOfMeasureQueryObject(IQueryObject<ProductsUnitOfMeasure, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Product_Id, UnitOfMeasure_Id, Base FROM ProductsUnitOfMeasures";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
