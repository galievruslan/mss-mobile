using System.Collections.Generic;
using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class PickUpProductPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IPickUpProductView _view;
        private readonly IDataPageRetriever<ProductsPrice> _productsPriceRetriever;
        private readonly Cache<ProductsPrice> _cache;
        private readonly Order _order; 

        public PickUpProductPresenter(IPickUpProductView view, int orderId)
        {
            _order = Order.GetById(orderId);
            _productsPriceRetriever = new ProductsPriceRetriever(_order.PriceList);
            _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 10);
            _view = view;
        }

        public void InitializeView()
        {
            _view.SetItemCount(_productsPriceRetriever.Count);
        }

        public IDictionary<string, string> GetItemData(int index)
        {
            ProductsPrice item = _cache.RetrieveElement(index);

            return new Dictionary<string, string>
                {
                    {"Name", item.Product.Name},
                    {"Price", item.Price.ToString(CultureInfo.InvariantCulture)},
                    {"Count", "0"}
                };
        }
    }
}
