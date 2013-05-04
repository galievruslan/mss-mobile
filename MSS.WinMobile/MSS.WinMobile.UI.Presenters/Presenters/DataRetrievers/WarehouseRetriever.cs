using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class WarehouseRetriever : IDataPageRetriever<Warehouse> {
        private readonly WarehouseStorageRepository _warehouseStorageRepository;
        public WarehouseRetriever(WarehouseStorageRepository warehouseStorageRepository) {
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