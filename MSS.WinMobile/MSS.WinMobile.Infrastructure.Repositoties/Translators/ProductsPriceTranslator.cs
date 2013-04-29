﻿using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ProductsPriceDataRecordTranslator : DataRecordTranslator<ProductsPrice>
    {
        protected override ProductsPrice TranslateOne(IDataRecord value)
        {
            var proxy = new ProductsPriceProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    ProductId = value.GetInt32(value.GetOrdinal("Product_Id")),
                    ProductName = value.GetString(value.GetOrdinal("Product_Name")),
                    PriceListId = value.GetInt32(value.GetOrdinal("PriceList_Id")),
                    Price = value.GetDecimal(value.GetOrdinal("Price"))
                };
            return proxy;
        }
    }
}
