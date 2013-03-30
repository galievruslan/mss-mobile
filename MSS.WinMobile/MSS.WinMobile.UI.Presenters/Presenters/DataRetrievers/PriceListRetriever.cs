using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class PriceListRetriever : IDataPageRetriever<PriceList>
    {
        public int Count
        {
            get
            {
                return PriceList.GetAll().Count();
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