using System.Data;
using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public class CustomerTranslator : Translator<Customer>
    {
        protected override Customer DataRecordToModel(IDataRecord value)
        {
            var customer = new Customer(value.GetInt32(value.GetOrdinal("Id")),
                value.GetString(value.GetOrdinal("Name")));
            return customer;
        }
    }
}
