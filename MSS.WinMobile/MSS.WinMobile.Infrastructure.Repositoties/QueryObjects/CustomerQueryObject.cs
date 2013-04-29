﻿using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class CustomerQueryObject : QueryObject<Customer>
    {
        public CustomerQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<Customer, IDataReader> translator)
            : base(connectionFactory, translator)
        {
        }

        private const string SelectQuery = "SELECT Id, Name FROM Customers";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
