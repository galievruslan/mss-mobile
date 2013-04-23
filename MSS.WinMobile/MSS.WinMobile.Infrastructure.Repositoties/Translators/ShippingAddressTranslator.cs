using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ShippingAddressTranslator : Translator<ShippingAddress>
    {
        protected override ShippingAddress DataRecordToModel(IDataRecord value)
        {
            var proxy = new ShippingAddressProxy();
            proxy.SetId(value.GetInt32(value.GetOrdinal("Id")));
            proxy.SetCustomerId(value.GetInt32(value.GetOrdinal("Customer_Id")));
            proxy.SetName(value.GetString(value.GetOrdinal("Name")));
            proxy.SetAddress(value.GetString(value.GetOrdinal("Address")));
            proxy.SetMine(value.GetBoolean(value.GetOrdinal("Mine")));
            return proxy;
        }
    }
}
