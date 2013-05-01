using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class PriceListRetriever : IDataPageRetriever<PriceList> {
        private readonly PriceListRepository _priceListRepository;
        public PriceListRetriever(PriceListRepository priceListRepository)
        {
            _priceListRepository = priceListRepository;
        }

        public int Count
        {
            get {
                var queryObject = _priceListRepository.Find();
                if (!string.IsNullOrEmpty(SearchCriteria))
                    queryObject = queryObject.Where("Name", new Contains(SearchCriteria));
                return queryObject.GetCount();
            }
        }

        public string SearchCriteria { private get; set; }

        public PriceList[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            var queryObject = _priceListRepository.Find();
            if (!string.IsNullOrEmpty(SearchCriteria))
                queryObject = queryObject.Where("Name", new Contains(SearchCriteria));
            return queryObject.OrderBy("Name", OrderDirection.Asceding).Page(lowerPageBoundary, rowsPerPage).ToArray();
        }
    }
}