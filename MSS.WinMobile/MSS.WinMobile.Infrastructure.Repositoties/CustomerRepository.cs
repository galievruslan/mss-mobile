﻿using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class CustomerRepository : Repository<Customer>
    {
        protected override QueryObject<Customer> GetQueryObject()
        {
            return new CustomerQueryObject(new CustomerTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO Customers (Id, Name) VALUES ({0}, '{1}')";
        protected override string GetSaveQueryFor(Customer model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"));
        }

        private const string DeleteQueryTemplate = "DELETE FROM Customers WHERE Id = {0}";
        protected override string GetDeleteQueryFor(Customer model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
