using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class ProductsPriceRetriever : IDataPageRetriever<ProductsPrice>
    {
        private readonly PriceList _priceList;
        public ProductsPriceRetriever(PriceList priceList)
        {
            _priceList = priceList;
        }

        public int Count
        {
            get {
                return _priceList.GetProductsPrices().Count();
            }
        }

        public ProductsPrice[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                _priceList.GetProductsPrices()
                          .OrderBy(
                              string.Format("{0}_{1}", Product.Table.TABLE_NAME, Product.Table.Fields.NAME),
                              OrderDirection.Asceding)
                          .Page(lowerPageBoundary, rowsPerPage)
                          .ToArray();
        }
    }
}
