using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class UnitOfMeasureTranslator : Translator<UnitOfMeasure>
    {
        protected override UnitOfMeasure DataRecordToModel(IDataRecord value)
        {
            var unitOfMeasure = new UnitOfMeasure(value.GetInt32(value.GetOrdinal("Id")),
                value.GetString(value.GetOrdinal("Name")));
            return unitOfMeasure;
        }
    }
}
