using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class WarehouseRetriever : IDataPageRetriever<Warehouse>
    {
        private int _cachedCount;
        public int Count
        {
            get
            {
                if (_cachedCount == 0)
                    _cachedCount = Warehouse.GetAll().Count();
                return _cachedCount;
            }
        }

        public Warehouse[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                Warehouse.GetAll()
                         .OrderBy(Warehouse.Table.Fields.ADDRESS, OrderDirection.Asceding)
                         .Skip(lowerPageBoundary)
                         .Take(rowsPerPage)
                         .ToArray();
        }
    }
}