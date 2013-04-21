using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class ManagerTranslator : Translator<Manager>
    {
        protected override Manager DataRecordToModel(IDataRecord value)
        {
            var manager = new Manager(value.GetInt32(value.GetOrdinal("Id")),
                value.GetString(value.GetOrdinal("Name")));
            return manager;
        }
    }
}
