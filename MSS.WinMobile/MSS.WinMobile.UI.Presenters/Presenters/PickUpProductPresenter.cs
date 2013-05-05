using System.Collections.Generic;
using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class PickUpProductPresenter : IListPresenter<PickUpProductViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IPickUpProductView _view;
        private IRepositoryFactory _repositoryFactory;

        private readonly IDataPageRetriever<ProductsPrice> _productsPriceRetriever;
        private readonly Cache<ProductsPrice> _cache;
        //private readonly Order _order; 

        public PickUpProductPresenter(IPickUpProductView view, IRepositoryFactory repositoryFactory, int priceListId) {
            _repositoryFactory = repositoryFactory;
            var productsPriceRepository = _repositoryFactory.CreateRepository<ProductsPrice>();
            var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
            _productsPriceRetriever = new ProductsPriceRetriever(priceListRepository.GetById(priceListId));
            _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 10);
            _view = view;

            //foreach (var orderItem in _order.Items())
            //{
            //    _values.Add(orderItem.Product.Id, orderItem.Quantity);
            //}
        }

        public IDictionary<string, string> GetItemData(int index)
        {
            ProductsPrice productsPrice = _cache.RetrieveElement(index);
            return new Dictionary<string, string>
                {
                    //{"Name", productsPrice.Product.Name},
                    {"Price", productsPrice.Price.ToString(CultureInfo.InvariantCulture)},
                    {"GetCount", CurrentItemCount(productsPrice.ProductId).ToString(CultureInfo.InvariantCulture)}
                };
        }

        readonly Dictionary<int, int> _values = new Dictionary<int, int>();

        private const int MaxValue = 999;
        public void AddDigit(int index, int count)
        {
            ProductsPrice selectedProductPrice = _cache.RetrieveElement(index);
            if (selectedProductPrice != null)
            {
                if (_values.ContainsKey(selectedProductPrice.ProductId))
                {
                    if (_values[selectedProductPrice.ProductId] * 10 + count < MaxValue)
                        _values[selectedProductPrice.ProductId] = _values[selectedProductPrice.ProductId]*10 + count;
                }
                else
                {
                    _values.Add(selectedProductPrice.ProductId, count);
                }
            }
        }

        public void RemoveDigit(int index)
        {
            ProductsPrice selectedProductPrice = _cache.RetrieveElement(index);
            if (selectedProductPrice != null)
            {
                if (_values.ContainsKey(selectedProductPrice.ProductId))
                {
                    _values[selectedProductPrice.ProductId] = _values[selectedProductPrice.ProductId] / 10;
                    if (_values[selectedProductPrice.ProductId] == 0)
                        _values.Remove(selectedProductPrice.ProductId);
                }
            }
        }

        private int CurrentItemCount(int productId)
        {
            var count = 0;
            if (_values.ContainsKey(productId))
                count = _values[productId];

            return count;
        }

        public IDictionary<int, int> GetValues()
        {
            return _values;
        }

        public int InitializeListSize() {
            return _productsPriceRetriever.Count;
        }

        public PickUpProductViewModel GetItem(int index) {
            ProductsPrice item = _cache.RetrieveElement(index);
            return new PickUpProductViewModel {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = 0
            };
        }
    }
}
