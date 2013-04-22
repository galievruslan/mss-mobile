using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class StatusTranslator : Translator<Status>
    {
        protected override Status DataRecordToModel(IDataRecord value)
        {
            var status = new Status(value.GetInt32(value.GetOrdinal("Id")),
                value.GetString(value.GetOrdinal("Name")));
            return status;
        }
    }
}
