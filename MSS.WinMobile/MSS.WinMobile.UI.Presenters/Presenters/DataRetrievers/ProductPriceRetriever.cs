using System.Text;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;
using System.Linq;
using AppCache = MSS.WinMobile.Application.Cache.Cache;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class ProductsPriceRetriever : IDataPageRetriever<ProductsPrice> {
        private readonly PriceList _priceList;
        public ProductsPriceRetriever(PriceList priceList) {
            _priceList = priceList;
        }

        private readonly Category _category;
        public ProductsPriceRetriever(PriceList priceList, Category category)
            : this(priceList) {
            _category = category;
        }

        private readonly string _searchCriteria;
        public ProductsPriceRetriever(PriceList priceList, Category category, string searchCriteria)
        :this(priceList, category) {
            _searchCriteria = searchCriteria;
        }

        public ProductsPriceRetriever(PriceList priceList, string searchCriteria)
            : this(priceList) {
            _searchCriteria = searchCriteria;
        }

        public int Count
        {
            get {
                if (_priceList == null)
                    return 0;

                var cacheKeyBuilder = new StringBuilder();
                cacheKeyBuilder.Append("ProductPrices ");
                if (_category != null)
                    cacheKeyBuilder.Append(string.Format("Category_Id = {0}", _category.Id));
                if (!string.IsNullOrEmpty(_searchCriteria))
                    cacheKeyBuilder.Append(string.Format("Search_Criteria = {0}", _searchCriteria));
                string cacheKey = cacheKeyBuilder.ToString();

                if (AppCache.Contains(cacheKey))
                    return AppCache.Get<int>(cacheKey);

                IQueryObject<ProductsPrice> queryObject = _priceList.Lines;
                if (_category != null)
                    queryObject = queryObject.Where(new PriceOfProductWithCategorySpec(_category));

                if (!string.IsNullOrEmpty(_searchCriteria))
                    queryObject =
                        queryObject.Where(new ProductPriceWithNameLikeSpec(_searchCriteria));

                int count = queryObject.GetCount();
                AppCache.Add(cacheKey, count);
                return count;
            }
        }

        public ProductsPrice[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage) {
            if (_priceList == null)
                return new ProductsPrice[0];

            IQueryObject<ProductsPrice> queryObject = _priceList.Lines;
            if (_category != null)
                queryObject = queryObject.Where(new PriceOfProductWithCategorySpec(_category));

            if (!string.IsNullOrEmpty(_searchCriteria))
                queryObject =
                    queryObject.Where(new ProductPriceWithNameLikeSpec(_searchCriteria));

            return queryObject.OrderBy("Product_Name", OrderDirection.Asceding)
                              .Paged(lowerPageBoundary, rowsPerPage)
                              .ToArray();
        }
    }
}
