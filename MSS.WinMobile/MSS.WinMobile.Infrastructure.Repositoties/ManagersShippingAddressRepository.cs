using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties
{
    public class ManagersShippingAddressRepository : Repository<ManagersShippingAddress>
    {
        public ManagersShippingAddressRepository(SqliteConnectionFactory connectionFactory, SqliteUnitOfWork unitOfWork)
            : base(connectionFactory, unitOfWork)
        {
        }

        protected override QueryObject<ManagersShippingAddress> GetQueryObject()
        {
            return new ManagersShippingAddressQueryObject(ConnectionFactory, new ManagersShippingAddressTranslator());
        }

        private const string SaveQueryTemplate = "INSERT OR REPLACE INTO ManagersShippingAddresses (Id, Manager_Id, ShippingAddress_Id) VALUES ({0}, {1}, {2})";
        protected override string GetSaveQueryFor(ManagersShippingAddress model)
        {
            return string.Format(SaveQueryTemplate, model.Id, model.ManagerId, model.ShippingAddressId);
        }

        private const string DeleteQueryTemplate = "DELETE FROM ManagersShippingAddresses WHERE Id = {0}";
        protected override string GetDeleteQueryFor(ManagersShippingAddress model)
        {
            return string.Format(DeleteQueryTemplate, model.Id);
        }
    }
}
