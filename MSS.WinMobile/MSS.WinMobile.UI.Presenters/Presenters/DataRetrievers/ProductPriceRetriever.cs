using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects.Conditions;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class ProductsPriceRetriever : IDataPageRetriever<ProductsPrice> {
        private readonly ProductsPriceRepository _productsPriceRepository;
        private readonly PriceList _priceList;
        public ProductsPriceRetriever(ProductsPriceRepository productsPriceRepository, PriceList priceList) {
            _productsPriceRepository = productsPriceRepository;
            _priceList = priceList;
        }

        public int Count
        {
            get { return _productsPriceRepository.Find().Where("PriceList_Id", new Equals(_priceList.Id)).GetCount(); }
        }

        public ProductsPrice[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _productsPriceRepository.Find().Where("PriceList_Id", new Equals(_priceList.Id))
                                        .OrderBy("Product_Name", OrderDirection.Asceding)
                                        .Page(lowerPageBoundary, rowsPerPage)
                                        .ToArray();
        }
    }
}
