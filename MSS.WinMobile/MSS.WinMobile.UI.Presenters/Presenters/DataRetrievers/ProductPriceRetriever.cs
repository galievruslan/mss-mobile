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

        private readonly int[] _categoryIds = new int[0];
        public ProductsPriceRetriever(PriceList priceList, int[] categoryIds)
            : this(priceList) {
                _categoryIds = categoryIds;
        }

        private readonly string _searchCriteria;
        public ProductsPriceRetriever(PriceList priceList, int[] categoryIds, string searchCriteria)
            : this(priceList, categoryIds)
        {
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
                cacheKeyBuilder.Append(string.Format("Price Id = {0}", _priceList.Id));
                if (_categoryIds.Length > 0) {
                    var cacheCategoryKeyBuilder = new StringBuilder();
                    foreach (var categoryId in _categoryIds) {
                        cacheCategoryKeyBuilder.Append(categoryId);
                        cacheCategoryKeyBuilder.Append(',');
                    }

                    cacheKeyBuilder.Append(string.Format("Category_Ids = {0}", cacheCategoryKeyBuilder));
                }
                if (!string.IsNullOrEmpty(_searchCriteria))
                    cacheKeyBuilder.Append(string.Format("Search_Criteria = {0}", _searchCriteria));
                string cacheKey = cacheKeyBuilder.ToString();

                if (AppCache.Contains(cacheKey))
                    return AppCache.Get<int>(cacheKey);

                IQueryObject<ProductsPrice> queryObject = _priceList.Lines;
                if (_categoryIds.Length > 0)
                {
                    queryObject = queryObject.Where(new PriceOfProductWithCategorySpec(_categoryIds));
                }

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
            if (_categoryIds.Length > 0)
                queryObject = queryObject.Where(new PriceOfProductWithCategorySpec(_categoryIds));

            if (!string.IsNullOrEmpty(_searchCriteria))
                queryObject =
                    queryObject.Where(new ProductPriceWithNameLikeSpec(_searchCriteria));

            return queryObject.OrderBy("Product_Name", OrderDirection.Asceding)
                              .Paged(lowerPageBoundary, rowsPerPage)
                              .ToArray();
        }
    }
}
