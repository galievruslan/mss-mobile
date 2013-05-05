using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class WarehouseRetriever : IDataPageRetriever<Warehouse> {
        private readonly IStorageRepository<Warehouse> _warehouseStorageRepository;
        public WarehouseRetriever(IStorageRepository<Warehouse> warehouseStorageRepository) {
            _warehouseStorageRepository = warehouseStorageRepository;
        }

        public int Count
        {
            get
            {
                return _warehouseStorageRepository.Find().Count();
            }
        }

        public Warehouse[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _warehouseStorageRepository.Find()
                                    .OrderBy("Address", OrderDirection.Asceding)
                                    .Paged(lowerPageBoundary, rowsPerPage)
                                    .ToArray();
        }
    }
}