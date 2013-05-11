using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters.LookUps
{
    public class PickUpProductPresenter : IListPresenter<PickUpProductViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IPickUpProductView _view;
        private readonly IRepositoryFactory _repositoryFactory;

        private readonly IDataPageRetriever<ProductsPrice> _productsPriceRetriever;
        private readonly Cache<ProductsPrice> _cache;
        private readonly IList<PickUpProductViewModel> _pickUpProductViewModels;

        public PickUpProductPresenter(IPickUpProductView view, IRepositoryFactory repositoryFactory, OrderViewModel orderViewModel, IList<OrderItemViewModel> orderItemViewModels) {
            _repositoryFactory = repositoryFactory;
            var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
            _productsPriceRetriever = new ProductsPriceRetriever(priceListRepository.GetById(orderViewModel.PriceListId));
            _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 100);
            _view = view;

            _pickUpProductViewModels = new List<PickUpProductViewModel>();
            foreach (var orderItemViewModel in orderItemViewModels) {
                _pickUpProductViewModels.Add(new PickUpProductViewModel
                    {
                        ProductId = orderItemViewModel.ProductId,
                        ProductName = orderItemViewModel.ProductName,
                        Quantity = orderItemViewModel.Quantity,
                        Price = orderItemViewModel.Price
                    });
            }
        }

        private const int MaxValue = 10000;
        public void AddDigit(int count) {
            if (_selectedProductPrice != null) {
                PickUpProductViewModel pickUpProductViewModel =
                    _pickUpProductViewModels.FirstOrDefault(model => model.ProductId == _selectedProductPrice.ProductId);
                if (pickUpProductViewModel != null)
                {
                    if (pickUpProductViewModel.Quantity * 10 + count < MaxValue)
                        pickUpProductViewModel.Quantity = pickUpProductViewModel.Quantity * 10 + count;
                }
                else {
                    _pickUpProductViewModels.Add(new PickUpProductViewModel
                        {
                            ProductId = _selectedProductPrice.ProductId,
                            ProductName = _selectedProductPrice.ProductName,
                            Quantity = count,
                            Price = _selectedProductPrice.Price
                        });
                }
            }
        }

        public void RemoveDigit()
        {
            if (_selectedProductPrice != null)
            {
                PickUpProductViewModel pickUpProductViewModel =
                    _pickUpProductViewModels.FirstOrDefault(model => model.ProductId == _selectedProductPrice.ProductId);
                if (pickUpProductViewModel != null)
                {
                    pickUpProductViewModel.Quantity = pickUpProductViewModel.Quantity / 10;
                    if (pickUpProductViewModel.Quantity == 0)
                        _pickUpProductViewModels.Remove(pickUpProductViewModel);
                }
            }
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

        private ProductsPrice _selectedProductPrice;
        public void Select(int index) {
            _selectedProductPrice = _cache.RetrieveElement(index);
        }

        public PickUpProductViewModel SelectedModel {
            get {
                return _selectedProductPrice != null
                           ? new PickUpProductViewModel
                               {
                                   ProductId = _selectedProductPrice.ProductId,
                                   ProductName = _selectedProductPrice.ProductName,
                                   Price = _selectedProductPrice.Price
                               }
                           : null;
            }
        }

        public IList<PickUpProductViewModel> PickedUpProducts {
            get { return _pickUpProductViewModels; }
        }
    }
}
