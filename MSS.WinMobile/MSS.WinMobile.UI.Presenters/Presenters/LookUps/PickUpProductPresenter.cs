using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private readonly ILookUpService _lookUpService;

        private IDataPageRetriever<ProductsPrice> _productsPriceRetriever;
        private Cache<ProductsPrice> _cache;
        private readonly PriceListViewModel _priceListViewModel;
        private readonly IList<PickUpProductViewModel> _pickUpProductViewModels;

        public PickUpProductPresenter(IPickUpProductView view, IRepositoryFactory repositoryFactory, ILookUpService lookUpService, PriceListViewModel priceListViewModel, IEnumerable<OrderItemViewModel> orderItemViewModels) {
            _repositoryFactory = repositoryFactory;
            _lookUpService = lookUpService;
            _priceListViewModel = priceListViewModel;
            var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
            _productsPriceRetriever = new ProductsPriceRetriever(priceListRepository.GetById(_priceListViewModel.Id));
            _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 100);
            _view = view;

            _pickUpProductViewModels = new List<PickUpProductViewModel>();
            foreach (var orderItemViewModel in orderItemViewModels) {
                _pickUpProductViewModels.Add(new PickUpProductViewModel {
                    OrderItemId = orderItemViewModel.Id,
                    ProductId = orderItemViewModel.ProductId,
                    ProductName = orderItemViewModel.ProductName,
                    Quantity = orderItemViewModel.Quantity,
                    Price = orderItemViewModel.Price,
                    UnitOfMeasureId = orderItemViewModel.UnitOfMeasureId,
                    UnitOfMeasureName = orderItemViewModel.UnitOfMeasureName
                });
            }
        }

        private const int MaxValue = 10000;
        public void AddDigit(int count) {
            if (SelectedModel != null) {
                PickUpProductViewModel pickUpProductViewModel =
                    _pickUpProductViewModels.FirstOrDefault(model => model.ProductId == SelectedModel.ProductId);
                if (pickUpProductViewModel != null)
                {
                    if (pickUpProductViewModel.Quantity * 10 + count < MaxValue)
                        pickUpProductViewModel.Quantity = pickUpProductViewModel.Quantity * 10 + count;
                }
                else {
                    _pickUpProductViewModels.Add(new PickUpProductViewModel {
                        ProductId = SelectedModel.ProductId,
                        ProductName = SelectedModel.ProductName,
                        Quantity = count,
                        Price = SelectedModel.Price,
                        UnitOfMeasureId = SelectedModel.UnitOfMeasureId
                    });
                }
            }
        }

        public void RemoveDigit()
        {
            if (SelectedModel != null)
            {
                PickUpProductViewModel pickUpProductViewModel =
                    _pickUpProductViewModels.FirstOrDefault(model => model.ProductId == SelectedModel.ProductId);
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

            var pickUpProductViewModel =
                _pickUpProductViewModels.FirstOrDefault(model => model.ProductId == item.ProductId);
            return pickUpProductViewModel ?? new PickUpProductViewModel {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = 0
            };
        }

        private ProductsPrice _selectedProductPrice;

        public void Select(int index) {
            _selectedProductPrice = _cache.RetrieveElement(index);
            SelectedModel =
                _pickUpProductViewModels.FirstOrDefault(
                    model => model.ProductId == _selectedProductPrice.ProductId) ??
                new PickUpProductViewModel {
                    ProductId = _selectedProductPrice.ProductId,
                    ProductName = _selectedProductPrice.ProductName,
                    Price = _selectedProductPrice.Price
                };
        }

        public PickUpProductViewModel SelectedModel { get; private set; }

        public IList<PickUpProductViewModel> PickedUpProducts {
            get { return _pickUpProductViewModels; }
        }

        private CategoryViewModel _categoryFilterViewModel;
        public void ChangeCategoryFilter() {
            if (_categoryFilterViewModel == null) {
                _categoryFilterViewModel = new CategoryViewModel {ParentId = 0};
            }
            var lookedUpCategory = _lookUpService.LookUpCategory(_categoryFilterViewModel);
            if (lookedUpCategory != null) {
                var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
                var categoryRepository = _repositoryFactory.CreateRepository<Category>();

                _categoryFilterViewModel = lookedUpCategory;
                _productsPriceRetriever = string.IsNullOrEmpty(_searchCriteria)
                                          ? new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                categoryRepository.GetById(
                                                    _categoryFilterViewModel.Id))
                                          : new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                categoryRepository.GetById(
                                                    _categoryFilterViewModel.Id), _searchCriteria);
                _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 100);
                _view.SetCategoryFilter(lookedUpCategory.Name);
            }
        }

        public void ClearCategoryFilter() {
            _categoryFilterViewModel = null;
            var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
            _productsPriceRetriever = string.IsNullOrEmpty(_searchCriteria)
                                          ? new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id))
                                          : new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                _searchCriteria);
            _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 100);
        }

        private string _searchCriteria;
        public void Search(string criteria) {
            _searchCriteria = criteria;
            var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
            var categoryRepository = _repositoryFactory.CreateRepository<Category>();

            _productsPriceRetriever = _categoryFilterViewModel == null
                                          ? new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                _searchCriteria)
                                          : new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                categoryRepository.GetById(
                                                    _categoryFilterViewModel.Id), _searchCriteria);
            _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 100);
            SelectedModel = null;
        }

        public void ClearSearch() {
            _searchCriteria = string.Empty;
            var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
            var categoryRepository = _repositoryFactory.CreateRepository<Category>();
            _productsPriceRetriever = _categoryFilterViewModel == null
                                          ? new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id))
                                          : new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                categoryRepository.GetById(
                                                    _categoryFilterViewModel.Id));
            _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 100);
            SelectedModel = null;
        }

        public void ShowDetails() {
            if (SelectedModel != null) {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(string.Format("<b>{0} </b>", "Product name:"));
                stringBuilder.Append(SelectedModel.ProductName);
                stringBuilder.Append("</br>");
                stringBuilder.Append(string.Format("<b>{0} </b>", "Product price for item:"));
                stringBuilder.Append(SelectedModel.Price);

                _view.ShowDetails(stringBuilder.ToString());
            }
        }

        public IEnumerable<UnitOfMeasureViewModel> GetProductsUntisOfMeasure() {
            var unitOfMeasureViewModels =
                new List<UnitOfMeasureViewModel>();

            if (SelectedModel != null) {
                var productRepository = _repositoryFactory.CreateRepository<Product>();
                var product = productRepository.GetById(SelectedModel.ProductId);
                var productUnitsOfMeasure = product.UnitsOfMeasures.ToArray();
                unitOfMeasureViewModels.AddRange(
                    productUnitsOfMeasure
                           .Select(unitOfMeasure => new UnitOfMeasureViewModel {
                               Id = unitOfMeasure.UnitOfMeasureId,
                               Name = unitOfMeasure.UnitOfMeasureName
                           }));

                if (SelectedModel.UnitOfMeasureId == 0) {
                    var baseUnitOfMeasure = productUnitsOfMeasure.FirstOrDefault(uom => uom.Base);
                    if (baseUnitOfMeasure != null) {
                        SelectedModel.UnitOfMeasureId = baseUnitOfMeasure.UnitOfMeasureId;
                        SelectedModel.UnitOfMeasureName = baseUnitOfMeasure.UnitOfMeasureName;
                    }
                }
            }

            return unitOfMeasureViewModels;
        }

        public void ChangeUnitOfMeasure(UnitOfMeasureViewModel unitOfMeasureViewModel) {
            if (SelectedModel != null) {
                PickUpProductViewModel pickUpProductViewModel =
                    _pickUpProductViewModels.FirstOrDefault(model => model.ProductId == SelectedModel.ProductId);
                if (pickUpProductViewModel != null) {
                    pickUpProductViewModel.UnitOfMeasureId = unitOfMeasureViewModel.Id;
                    pickUpProductViewModel.UnitOfMeasureName = unitOfMeasureViewModel.Name;
                }
                else {
                    SelectedModel.UnitOfMeasureId = unitOfMeasureViewModel.Id;
                    SelectedModel.UnitOfMeasureName = unitOfMeasureViewModel.Name;
                }
            }
        }
    }
}
