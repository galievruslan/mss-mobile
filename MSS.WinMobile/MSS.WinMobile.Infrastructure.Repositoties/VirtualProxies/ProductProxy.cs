using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class ProductProxy : Product
    {
        private readonly IStorageRepository<ProductsUnitOfMeasure> _productsUnitsOfMeasureRepository;
        public ProductProxy(IStorageRepository<ProductsUnitOfMeasure> productsUnitsOfMeasureRepository) {
            _productsUnitsOfMeasureRepository = productsUnitsOfMeasureRepository;
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

        new public int CategoryId
        {
            get { return base.CategoryId; }
            set { base.CategoryId = value; }
        }

        public override IQueryObject<ProductsUnitOfMeasure> UnitsOfMeasures {
            get {
                var productUnitsOfMeasuresSpec = new ProductUnitsOfMeasuresSpec(this);
                return _productsUnitsOfMeasureRepository.Find().Where(productUnitsOfMeasuresSpec);
            }
        }
    }
}
