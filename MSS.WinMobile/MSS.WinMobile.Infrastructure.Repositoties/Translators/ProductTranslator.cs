using System.Data;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public class ProductDataRecordTranslator : DataRecordTranslator<Product> {
        private readonly IRepositoryFactory _repositoryFactory;
        public ProductDataRecordTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        protected override Product TranslateOne(IDataRecord value)
        {
            var proxy = new ProductProxy(_repositoryFactory.CreateRepository<ProductsUnitOfMeasure>())
                {
                    Id = value.GetInt32(value.GetOrdinal("Id")),
                    Name = value.GetString(value.GetOrdinal("Name")),
                    CategoryId = value.GetInt32(value.GetOrdinal("Category_Id"))
                };
            return proxy;
        }
    }
}
