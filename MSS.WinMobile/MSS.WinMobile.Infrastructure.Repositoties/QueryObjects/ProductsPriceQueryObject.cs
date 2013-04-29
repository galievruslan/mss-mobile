﻿using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class ProductsPriceQueryObject : QueryObject<ProductsPrice>
    {
        public ProductsPriceQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<ProductsPrice, IDataReader> translator)
            : base(connectionFactory, translator)
        {
        }

        private const string SelectQuery =
            "SELECT productsPrices.Id, productsPrices.Product_Id, products.Name as Product_Name, productsPrices.PriceList_Id, productsPrices.Price " +
            "FROM ProductsPrices productsPrices Left Join " +
            "Products products on productsPrices.Product_Id = products.Id";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
