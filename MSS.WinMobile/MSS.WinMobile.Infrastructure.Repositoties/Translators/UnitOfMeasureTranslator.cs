using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class UnitOfMeasureDataRecordTranslator : DataRecordTranslator<UnitOfMeasure>
    {
        protected override UnitOfMeasure TranslateOne(IDataRecord value)
        {
            var proxy = new UnitOfMeasureProxy
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Name = value.GetString(value.GetOrdinal("Name"))
                };
            return proxy;
        }
    }
}
