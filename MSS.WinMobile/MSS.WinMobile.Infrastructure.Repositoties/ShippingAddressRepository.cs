using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class ShippingAddressRepository : Repository<ShippingAddress>
    {
        public ShippingAddressRepository(SQLiteConnectionFactory connectionFactory, SQLiteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<ShippingAddress> GetQueryObject()
        {
            return new ShippingAddressQueryObject(ConnectionFactory, new ShippingAddressTranslator());
        }

        private const string SaveQueryTemplate =
            "INSERT OR REPLACE INTO ShippingAddresses (Id, Name, Address, Customer_Id) VALUES ({0}, '{1}', '{2}', {3})";
        protected override string GetSaveQueryFor(ShippingAddress model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.Name.Replace("'", "''"),
                                 model.Address.Replace("'", "''"), model.CustomerId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM ShippingAddresses WHERE Id = {0}";
        protected override string GetDeleteQueryFor(ShippingAddress model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
