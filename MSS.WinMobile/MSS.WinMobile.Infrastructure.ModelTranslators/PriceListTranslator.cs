using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web.Repositories.Dtos;

namespace MSS.WinMobile.Infrastructure.Sqlite.ModelTranslators
{
    public class PriceListTranslator : DtoTranslator<PriceList, PriceListDto> {
        private readonly IRepositoryFactory _repositoryFactory;
        public PriceListTranslator(IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
        }

        public override PriceList Translate(PriceListDto value)
        {
            var proxy = new PriceListProxy(_repositoryFactory.CreateRepository<ProductsPrice>())
                {
                    Id = value.Id,
                    Name = value.Name
                };
            return proxy;
        }
    }
}
