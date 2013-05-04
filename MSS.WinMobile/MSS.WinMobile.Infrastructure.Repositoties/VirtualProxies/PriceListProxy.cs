using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class PriceListProxy : PriceList {
        private readonly IStorageRepository<ProductsPrice> _productPriceRepository;
        public PriceListProxy(IStorageRepository<ProductsPrice> productPriceRepository) {
            _productPriceRepository = productPriceRepository;
        }

        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public override IQueryObject<ProductsPrice> Lines {
            get {
                var pricesLinesSpec = new PricesLinesSpec(this);
                return _productPriceRepository.Find().Where(pricesLinesSpec);
            }
        }
    }
}
