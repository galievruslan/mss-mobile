using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class ShippingAddressSQLiteRepository : SQLiteRepository<ShippingAddress>
    {
        public ShippingAddressSQLiteRepository(IConnectionFactory<SQLiteConnection> connectionFactory, SQLiteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<ShippingAddress> GetQueryObject()
        {
            return new ShippingAddressQueryObject(ConnectionFactory, new ShippingAddressDataRecordTranslator());
        }

        private const string SaveQueryTemplate =
            "INSERT OR REPLACE INTO ShippingAddresses (Id, Name, Address, Customer_Id, Mine) VALUES ({0}, '{1}', '{2}', {3}, {4})";
        protected override string GetSaveQueryFor(ShippingAddress model) {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"),
                                 model.Address.Replace("'", "''"), model.CustomerId, model.Mine ? 1 : 0);
        }

        private const string DeleteQueryTemplate = "DELETE FROM ShippingAddresses WHERE Id = {0}";
        protected override string GetDeleteQueryFor(ShippingAddress model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
