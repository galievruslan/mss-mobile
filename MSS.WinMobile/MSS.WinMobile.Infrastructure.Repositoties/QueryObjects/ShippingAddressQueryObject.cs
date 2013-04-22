using System.Data.SQLite;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class ShippingAddressQueryObject : QueryObject<ShippingAddress>
    {
        public ShippingAddressQueryObject(SQLiteConnectionFactory connectionFactory, ITranslator<ShippingAddress> translator)
            : base(connectionFactory, translator)
        {
        }

        public ShippingAddressQueryObject(IQueryObject<ShippingAddress, string, SQLiteConnection> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Name, Address, Customer_Id FROM ShippingAddresses";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
