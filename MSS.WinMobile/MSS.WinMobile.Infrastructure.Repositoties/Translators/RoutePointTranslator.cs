using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class RoutePointTranslator : Translator<RoutePoint>
    {
        protected override RoutePoint DataRecordToModel(IDataRecord value)
        {
            var productsPrice = new RoutePoint(value.GetInt32(value.GetOrdinal("Id")),
                value.GetInt32(value.GetOrdinal("Route_Id")),
                value.GetInt32(value.GetOrdinal("ShippingAddress_Id")),
                value.GetString(value.GetOrdinal("ShippingAddress_Name")),
                value.GetInt32(value.GetOrdinal("Status_Id")));
            return productsPrice;
        }
    }
}
