﻿using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class ProductDataRecordTranslator : DataRecordTranslator<Product>
    {
        protected override Product TranslateOne(IDataRecord value)
        {
            var proxy = new ProductProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Name = value.GetString(value.GetOrdinal("Name")),
                    CategoryId = value.GetInt32(value.GetOrdinal("Category_Id"))
                };
            return proxy;
        }
    }
}