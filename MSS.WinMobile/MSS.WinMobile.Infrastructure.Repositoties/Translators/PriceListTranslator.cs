using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class PriceListTranslator : Translator<PriceList>
    {
        protected override PriceList DataRecordToModel(IDataRecord value)
        {
            var proxy = new PriceListProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Name = value.GetString(value.GetOrdinal("Name"))
                };
            return proxy;
        }
    }
}
