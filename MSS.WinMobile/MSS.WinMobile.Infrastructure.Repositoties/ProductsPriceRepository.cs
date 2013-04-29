﻿using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class ProductsPriceSQLiteRepository : SQLiteRepository<ProductsPrice>
    {
        public ProductsPriceSQLiteRepository(IConnectionFactory<SQLiteConnection> connectionFactory, SQLiteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<ProductsPrice> GetQueryObject()
        {
            return new ProductsPriceQueryObject(ConnectionFactory, new ProductsPriceDataRecordTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO ProductsPrices (Id, Product_Id, PriceList_Id, Price) VALUES ({0}, {1}, {2}, {3})";
        protected override string GetSaveQueryFor(ProductsPrice model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.ProductId, model.PriceListId, model.Price);
        }

        private const string DeleteQueryTemplate = "DELETE FROM ProductsPrices WHERE Id = {0}";
        protected override string GetDeleteQueryFor(ProductsPrice model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
