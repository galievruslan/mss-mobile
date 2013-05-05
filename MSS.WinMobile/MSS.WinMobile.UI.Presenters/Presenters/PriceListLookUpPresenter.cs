using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Exceptions;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class PriceListLookUpPresenter : IListPresenter<PickUpProductViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IPriceListLookUpView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private ProductsPriceRetriever _productsPricesRetriever;
        private Cache<ProductsPrice> _cache;
        private int _orderId;

        public PriceListLookUpPresenter(IPriceListLookUpView view, IRepositoryFactory repositoryFactory, int orderId) {
            _view = view;
            _repositoryFactory = repositoryFactory;
        }

        private PriceList _selectedPriceList;

        public void SelectItem(int index)
        {
            //_selectedPriceList = _cache.RetrieveElement(index);
        }

        public int GetSelectedItemId()
        {
            if (_selectedPriceList != null)
                return _selectedPriceList.Id;

            throw new NoSelectedItemsException();
        }

        private string _searchCriteria;
        public void Search(string criteria) {
            _searchCriteria = criteria;
        }

        public int InitializeListSize() {
            var ordersRepository = _repositoryFactory.CreateRepository<Order>();
            Order order = ordersRepository.GetById(_orderId);
            var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
            PriceList priceList = priceListRepository.GetById(order.PriceListId);

            _productsPricesRetriever = new ProductsPriceRetriever(priceList);

            _cache = new Cache<ProductsPrice>(_productsPricesRetriever, 10);
            return _productsPricesRetriever.Count;
        }

        public PickUpProductViewModel GetItem(int index) {
            ProductsPrice item = _cache.RetrieveElement(index);
            return new PickUpProductViewModel {
                ProductId = item.Id,
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = 0
            };
        }
    }
}
