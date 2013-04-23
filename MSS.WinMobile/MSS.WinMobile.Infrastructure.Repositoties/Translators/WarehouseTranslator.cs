﻿using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class WarehouseTranslator : Translator<Warehouse>
    {
        protected override Warehouse DataRecordToModel(IDataRecord value)
        {
            var proxy = new WarehouseProxy();
            proxy.SetId(value.GetInt32(value.GetOrdinal("Id")));
            proxy.SetAddress(value.GetString(value.GetOrdinal("Address")));
            return proxy;
        }
    }
}
