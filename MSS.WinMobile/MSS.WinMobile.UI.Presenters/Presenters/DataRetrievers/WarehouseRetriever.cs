using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class WarehouseRetriever : IDataPageRetriever<Warehouse> {
        private readonly IStorageRepository<Warehouse> _warehouseStorageRepository;
        public WarehouseRetriever(IStorageRepository<Warehouse> warehouseStorageRepository) {
            _warehouseStorageRepository = warehouseStorageRepository;
        }

        private readonly string _searchCriteria;
        public WarehouseRetriever(IStorageRepository<Warehouse> warehouseStorageRepository,
                                 string searchCriteria)
            : this(warehouseStorageRepository) {
            _searchCriteria = searchCriteria;
        }

        public int Count {
            get {
                return string.IsNullOrEmpty(_searchCriteria)
                           ? _warehouseStorageRepository.Find().Count()
                           : _warehouseStorageRepository.Find()
                                                       .Where(
                                                           new WarehouseWithNameOrAddressLikeSpec(
                                                               _searchCriteria))
                                                       .Count();
            }
        }

        public Warehouse[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            IQueryObject<Warehouse> queryObject = _warehouseStorageRepository.Find();
            if (!string.IsNullOrEmpty(_searchCriteria))
                queryObject = queryObject.Where(new WarehouseWithNameOrAddressLikeSpec(_searchCriteria));

            return
                queryObject.OrderBy("Name", OrderDirection.Asceding)
                           .Paged(lowerPageBoundary, rowsPerPage)
                           .ToArray();
        }
    }
}