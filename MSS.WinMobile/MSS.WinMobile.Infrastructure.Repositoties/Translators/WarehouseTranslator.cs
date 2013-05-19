using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class WarehouseDataRecordTranslator : DataRecordTranslator<Warehouse>
    {
        protected override Warehouse TranslateOne(IDataRecord value)
        {
            var proxy = new WarehouseProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Name = value.GetString(value.GetOrdinal("Name")),
                    Address = value.GetString(value.GetOrdinal("Address")),
                    Default = value.GetBoolean(value.GetOrdinal("Default"))
                };
            return proxy;
        }
    }
}
