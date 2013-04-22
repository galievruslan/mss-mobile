using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class PriceListTranslator : Translator<PriceList>
    {
        protected override PriceList DataRecordToModel(IDataRecord value)
        {
            var priceList = new PriceList(value.GetInt32(value.GetOrdinal("Id")),
                value.GetString(value.GetOrdinal("Name")));
            return priceList;
        }
    }
}
