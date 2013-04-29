using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class WarehouseDataRecordTranslator : DataRecordTranslator<Warehouse>
    {
        protected override Warehouse TranslateOne(IDataRecord value)
        {
            var proxy = new WarehouseProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Address = value.GetString(value.GetOrdinal("Address"))
                };
            return proxy;
        }
    }
}
