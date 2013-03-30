using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class WarehouseRetriever : IDataPageRetriever<Warehouse>
    {
        public int Count
        {
            get
            {
                return Warehouse.GetAll().Count();
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