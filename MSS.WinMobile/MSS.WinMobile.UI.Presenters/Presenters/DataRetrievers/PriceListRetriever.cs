using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class PriceListRetriever : IDataPageRetriever<PriceList> {
        private readonly IStorageRepository<PriceList> _priceListStorageRepository;
        public PriceListRetriever(IStorageRepository<PriceList> priceListStorageRepository)
        {
            _priceListStorageRepository = priceListStorageRepository;
        }

        private readonly string _searchCriteria;
        public PriceListRetriever(IStorageRepository<PriceList> priceListStorageRepository,
                                 string searchCriteria)
            : this(priceListStorageRepository) {
            _searchCriteria = searchCriteria;
        }

        public int Count {
            get {
                return string.IsNullOrEmpty(_searchCriteria)
                           ? _priceListStorageRepository.Find().Count()
                           : _priceListStorageRepository.Find()
                                                       .Where(
                                                           new PriceListWithNameLikeSpec(
                                                               _searchCriteria))
                                                       .Count();
            }
        }

        public PriceList[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            IQueryObject<PriceList> queryObject = _priceListStorageRepository.Find();
            if (!string.IsNullOrEmpty(_searchCriteria))
                queryObject = queryObject.Where(new PriceListWithNameLikeSpec(_searchCriteria));

            return
                queryObject.OrderBy("Name", OrderDirection.Asceding)
                           .Paged(lowerPageBoundary, rowsPerPage)
                           .ToArray();
        }
    }
}