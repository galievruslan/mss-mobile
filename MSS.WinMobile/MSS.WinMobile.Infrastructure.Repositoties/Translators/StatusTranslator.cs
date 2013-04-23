﻿using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class StatusTranslator : Translator<Status>
    {
        protected override Status DataRecordToModel(IDataRecord value)
        {
            var proxy = new StatusProxy();
            proxy.SetId(value.GetInt32(value.GetOrdinal("Id")));
            proxy.SetName(value.GetString(value.GetOrdinal("Name")));
            return proxy;
        }
    }
}
