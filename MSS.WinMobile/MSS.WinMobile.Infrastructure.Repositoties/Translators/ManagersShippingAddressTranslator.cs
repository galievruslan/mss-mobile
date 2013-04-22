using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ManagersShippingAddressTranslator : Translator<ManagersShippingAddress>
    {
        protected override ManagersShippingAddress DataRecordToModel(IDataRecord value)
        {
            var managersShippingAddress = new ManagersShippingAddress(
                value.GetInt32(value.GetOrdinal("Id")),
                value.GetInt32(value.GetOrdinal("Manager_Id")),
                value.GetInt32(value.GetOrdinal("ShippingAddress_Id")),
                value.GetString(value.GetOrdinal("ShippingAddress_Name")));
            return managersShippingAddress;
        }
    }
}
