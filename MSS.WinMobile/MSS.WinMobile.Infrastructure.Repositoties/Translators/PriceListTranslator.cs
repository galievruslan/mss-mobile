using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class PriceListDataRecordTranslator : DataRecordTranslator<PriceList> {
        private readonly IRepositoryFactory _repositoryFactory;
        public PriceListDataRecordTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        protected override PriceList TranslateOne(IDataRecord value)
        {
            var proxy = new PriceListProxy(_repositoryFactory.CreateRepository<ProductsPrice>())
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Name = value.GetString(value.GetOrdinal("Name"))
                };
            return proxy;
        }
    }
}
