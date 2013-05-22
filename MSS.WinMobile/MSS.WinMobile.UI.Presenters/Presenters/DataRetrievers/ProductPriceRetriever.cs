using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class ProductsPriceRetriever : IDataPageRetriever<ProductsPrice> {
        private readonly PriceList _priceList;
        public ProductsPriceRetriever(PriceList priceList) {
            _priceList = priceList;
        }

        private readonly Category _category;
        public ProductsPriceRetriever(PriceList priceList, Category category) {
            _priceList = priceList;
            _category = category;
        }

        public int Count
        {
            get {
                if (_priceList == null)
                    return 0;

                IQueryObject<ProductsPrice> queryObject = _priceList.Lines;
                if (_category != null)
                    queryObject = queryObject.Where(new PriceOfProductWithCategorySpec(_category));

                return queryObject.Count();
            }
        }

        public ProductsPrice[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            if (_priceList == null)
                return new ProductsPrice[0];

            IQueryObject<ProductsPrice> queryObject = _priceList.Lines;
            if (_category != null)
                queryObject = queryObject.Where(new PriceOfProductWithCategorySpec(_category));


            return queryObject.OrderBy("Product_Name", OrderDirection.Asceding)
                              .Paged(lowerPageBoundary, rowsPerPage)
                              .ToArray();
        }
    }
}
