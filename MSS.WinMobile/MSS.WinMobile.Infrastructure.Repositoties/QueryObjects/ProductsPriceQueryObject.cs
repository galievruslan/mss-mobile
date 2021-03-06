﻿using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class ProductsPriceQueryObject : QueryObject<ProductsPrice>
    {
        public ProductsPriceQueryObject(IStorage storage,
                                        ISpecificationTranslator<ProductsPrice> specificationTranslator,
                                        DataRecordTranslator<ProductsPrice> translator)
            : base(storage, specificationTranslator, translator) {}

        private const string SelectQuery =
            "SELECT productsPrices.Id, " +
            "productsPrices.Product_Id, " +
            "products.Name as Product_Name, " +
            "productsPrices.PriceList_Id, " +
            "productsPrices.Price, " +
            "products.Category_Id as Product_Category_Id " +
            "FROM Products products " +
            "Left Join " +
            "ProductsPrices productsPrices on productsPrices.Product_Id = products.Id";
        protected override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
