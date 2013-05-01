using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class WarehouseRetriever : IDataPageRetriever<Warehouse> {
        private readonly WarehouseRepository _warehouseRepository;
        public WarehouseRetriever(WarehouseRepository warehouseRepository) {
            _warehouseRepository = warehouseRepository;
        }

        public int Count
        {
            get
            {
                return _warehouseRepository.Find().GetCount();
            }
        }

        public Warehouse[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _warehouseRepository.Find()
                                    .OrderBy("Address", OrderDirection.Asceding)
                                    .Page(lowerPageBoundary, rowsPerPage)
                                    .ToArray();
        }
    }
}