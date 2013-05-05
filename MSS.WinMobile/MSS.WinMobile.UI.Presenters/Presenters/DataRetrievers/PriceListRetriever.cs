using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class PriceListRetriever : IDataPageRetriever<PriceList> {
        private readonly IStorageRepository<PriceList> _priceListStorageRepository;
        public PriceListRetriever(IStorageRepository<PriceList> priceListStorageRepository)
        {
            _priceListStorageRepository = priceListStorageRepository;
        }

        public int Count
        {
            get {
                return _priceListStorageRepository.Find().Count();
            }
        }

        public PriceList[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _priceListStorageRepository.Find()
                                           .OrderBy("Name", OrderDirection.Asceding)
                                           .Paged(lowerPageBoundary, rowsPerPage)
                                           .ToArray();
        }
    }
}