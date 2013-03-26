using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class PriceListRetriever : IDataPageRetriever<PriceList>
    {
        private int _cachedCount;
        public int Count
        {
            get
            {
                if (_cachedCount == 0)
                    _cachedCount = PriceList.GetAll().Count();
                return _cachedCount;
            }
        }

        public PriceList[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                PriceList.GetAll()
                        .OrderBy(PriceList.Table.Fields.NAME, OrderDirection.Asceding)
                        .Skip(lowerPageBoundary)
                        .Take(rowsPerPage)
                        .ToArray();
        }
    }
}