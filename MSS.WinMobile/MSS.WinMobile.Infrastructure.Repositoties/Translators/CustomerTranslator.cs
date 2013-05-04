using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class CustomerTranslator : DataRecordTranslator<Customer> {
        private readonly IRepositoryFactory _repositoryFactory;
        public CustomerTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        protected override Customer TranslateOne(IDataRecord value)
        {
            var proxy = new CustomerProxy(_repositoryFactory.CreateRepository<ShippingAddress>())
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Name = value.GetString(value.GetOrdinal("Name"))
                };
            return proxy;
        }
    }
}
