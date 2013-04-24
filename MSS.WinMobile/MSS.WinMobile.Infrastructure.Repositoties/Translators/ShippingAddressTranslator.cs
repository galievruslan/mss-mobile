using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ShippingAddressTranslator : Translator<ShippingAddress>
    {
        protected override ShippingAddress DataRecordToModel(IDataRecord value)
        {
            var proxy = new ShippingAddressProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    CustomerId = value.GetInt32(value.GetOrdinal("Customer_Id")),
                    Name = value.GetString(value.GetOrdinal("Name")),
                    Address = value.GetString(value.GetOrdinal("Address")),
                    Mine = value.GetBoolean(value.GetOrdinal("Mine"))
                };
            return proxy;
        }
    }
}
