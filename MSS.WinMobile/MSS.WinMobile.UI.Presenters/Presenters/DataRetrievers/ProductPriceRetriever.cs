using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class ProductsPriceRetriever : IDataPageRetriever<ProductsPrice> {
        private readonly PriceList _priceList;
        public ProductsPriceRetriever(PriceList priceList) {
            _priceList = priceList;
        }

        public int Count
        {
            get { return _priceList.Lines.Count(); }
        }

        public ProductsPrice[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            return
                _priceList.Lines
                          .OrderBy("Product_Name", OrderDirection.Asceding)
                          .Paged(lowerPageBoundary, rowsPerPage)
                          .ToArray();
        }
    }
}
