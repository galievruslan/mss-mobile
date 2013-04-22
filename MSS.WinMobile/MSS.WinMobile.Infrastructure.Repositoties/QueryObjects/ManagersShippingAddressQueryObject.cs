using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class ManagersShippingAddressQueryObject : QueryObject<ManagersShippingAddress>
    {
        public ManagersShippingAddressQueryObject(SQLiteConnectionFactory connectionFactory, ITranslator<ManagersShippingAddress> translator)
            : base(connectionFactory, translator)
        {
        }

        public ManagersShippingAddressQueryObject(IQueryObject<ManagersShippingAddress, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery =
            "SELECT managersShippingAddresses.Id, managersShippingAddresses.Manager_Id, managersShippingAddresses.ShippingAddress_Id , shippingAddresses.Name as ShippingAddress_Name " +
            "FROM ManagersShippingAddresses managersShippingAddresses Left Join " +
            "ShippingAddresses shippingAddresses on managersShippingAddresses.ShippingAddress_Id  = shippingAddresses.Id";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
