using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ShippingAddressTranslator : Translator<ShippingAddress>
    {
        protected override ShippingAddress DataRecordToModel(IDataRecord value)
        {
            var shippingAddress = new ShippingAddress(value.GetInt32(value.GetOrdinal("Id")),
                value.GetInt32(value.GetOrdinal("Customer_Id")),
                value.GetString(value.GetOrdinal("Name")),
                value.GetString(value.GetOrdinal("Address")));
            return shippingAddress;
        }
    }
}
