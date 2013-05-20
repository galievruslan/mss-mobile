using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class ShippingAddressDataRecordTranslator : DataRecordTranslator<ShippingAddress>
    {
        protected override ShippingAddress TranslateOne(IDataRecord value)
        {
            var proxy = new ShippingAddressProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    CustomerId = value.GetInt32(value.GetOrdinal("Customer_Id")),
                    Name = value.GetString(value.GetOrdinal("Name")),
                    Address = value.GetString(value.GetOrdinal("Address"))
                };
            return proxy;
        }
    }
}
