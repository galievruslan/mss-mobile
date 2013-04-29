﻿using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class PriceListQueryObject : QueryObject<PriceList>
    {
        public PriceListQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<PriceList, IDataReader> translator)
            : base(connectionFactory, translator)
        {
        }

        private const string SelectQuery = "SELECT Id, Name FROM PriceLists";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
