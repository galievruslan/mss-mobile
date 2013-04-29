using System.Data;
using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class ShippingAddressQueryObject : QueryObject<ShippingAddress>
    {
        public ShippingAddressQueryObject(IConnectionFactory<SQLiteConnection> connectionFactory, ITranslator<ShippingAddress, IDataReader> translator)
            : base(connectionFactory, translator)
        {
        }

        private const string SelectQuery = "SELECT Id, Name, Address, Customer_Id, Mine FROM ShippingAddresses";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
