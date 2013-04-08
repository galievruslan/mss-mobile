using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class PriceListRetriever : IDataPageRetriever<PriceList>
    {
        public int Count
        {
            get
            {
                return string.IsNullOrEmpty(SearchCriteria)
                           ? PriceList.GetAll().Where(PriceList.Table.Fields.NAME, new Contains(SearchCriteria)).Count()
                           : PriceList.GetAll().Count();
            }
        }

        public string SearchCriteria { get; set; }

        public PriceList[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return string.IsNullOrEmpty(SearchCriteria)
                ? PriceList.GetAll()
                        .Where(PriceList.Table.Fields.NAME, new Contains(SearchCriteria))
                        .OrderBy(PriceList.Table.Fields.NAME, OrderDirection.Asceding)
                        .Page(lowerPageBoundary, rowsPerPage)
                        .ToArray()
                : PriceList.GetAll()
                        .OrderBy(PriceList.Table.Fields.NAME, OrderDirection.Asceding)
                        .Page(lowerPageBoundary, rowsPerPage)
                        .ToArray();
        }
    }
}