using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class WarehouseTranslator : Translator<Warehouse>
    {
        protected override Warehouse DataRecordToModel(IDataRecord value)
        {
            var warehouse = new Warehouse(value.GetInt32(value.GetOrdinal("Id")),
                value.GetString(value.GetOrdinal("Address")));
            return warehouse;
        }
    }
}
