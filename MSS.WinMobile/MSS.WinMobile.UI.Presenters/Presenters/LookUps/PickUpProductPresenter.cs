﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using log4net;
using AppCache = MSS.WinMobile.Application.Cache.Cache;

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

            string priceListCacheKey = string.Format("PriceList Id={0}", _priceListViewModel.Id);

            PriceList priceList;
            if (AppCache.Contains(priceListCacheKey))
                priceList = AppCache.Get<PriceList>(priceListCacheKey);
            else {
                var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
                priceList = priceListRepository.GetById(_priceListViewModel.Id);
                AppCache.Add(priceListCacheKey, priceList);
            }

            _productsPriceRetriever = new ProductsPriceRetriever(priceList);
            _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 50);
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
                    UnitOfMeasureName = orderItemViewModel.UnitOfMeasureName,
                    CountInUnitOfMeasure = orderItemViewModel.CountInUnitOfMeasure,
                    Amount = orderItemViewModel.Amount
                });
            }

            _view.SetAmount(_pickUpProductViewModels.Sum(model => model.Amount));
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
                else if (count != 0) {
                    pickUpProductViewModel = new PickUpProductViewModel {
                        ProductId = SelectedModel.ProductId,
                        ProductName = SelectedModel.ProductName,
                        Quantity = count,
                        Price = SelectedModel.Price,
                        UnitOfMeasureId = SelectedModel.UnitOfMeasureId,
                        UnitOfMeasureName = SelectedModel.UnitOfMeasureName,
                        CountInUnitOfMeasure = SelectedModel.CountInUnitOfMeasure
                    };

                    _pickUpProductViewModels.Add(pickUpProductViewModel);
                }

                if (pickUpProductViewModel != null)
                    pickUpProductViewModel.Amount = pickUpProductViewModel.Price*
                                                    pickUpProductViewModel.Quantity *
                                                    (decimal)pickUpProductViewModel.CountInUnitOfMeasure;
                _view.SetAmount(_pickUpProductViewModels.Sum(model => model.Amount));
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

                    pickUpProductViewModel.Amount = pickUpProductViewModel.Price *
                                                    pickUpProductViewModel.Quantity *
                                                    (decimal)pickUpProductViewModel.CountInUnitOfMeasure;
                }

                _view.SetAmount(_pickUpProductViewModels.Sum(model => model.Amount));
            }
        }

        public int InitializeListSize() {
            int count = _productsPriceRetriever.Count;
            return count;
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

        private IEnumerable<CategoryViewModel> _categoryFilterViewModel;
        public void ChangeCategoryFilter() {
            if (_categoryFilterViewModel == null) {
                _categoryFilterViewModel = new List<CategoryViewModel>();
            }
            var lookedUpCategories = _lookUpService.LookUpCategories(_categoryFilterViewModel.FirstOrDefault());
            var categoryFilterViewModel = lookedUpCategories as CategoryViewModel[] ?? lookedUpCategories.ToArray();
            if (lookedUpCategories != null && categoryFilterViewModel.Count() != 0)
            {
                var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();

                _categoryFilterViewModel = categoryFilterViewModel;
                _productsPriceRetriever = string.IsNullOrEmpty(_searchCriteria)
                                          ? new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                _categoryFilterViewModel.Select(model => model.Id).ToArray())
                                          : new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                _categoryFilterViewModel.Select(model => model.Id).ToArray(), 
                                                _searchCriteria);
                _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 100);


                string categoryFilter = string.Empty;
                CategoryViewModel topCategoryViewModel = categoryFilterViewModel.FirstOrDefault();
                if (topCategoryViewModel != null)
                    categoryFilter = topCategoryViewModel.Name;

                _view.SetCategoryFilter(categoryFilter);
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

            _productsPriceRetriever = _categoryFilterViewModel == null
                                          ? new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                _searchCriteria)
                                          : new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                _categoryFilterViewModel.Select(model => model.Id).ToArray(),
                                                _searchCriteria);
            _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 100);
            SelectedModel = null;
        }

        public void ClearSearch() {
            _searchCriteria = string.Empty;
            var priceListRepository = _repositoryFactory.CreateRepository<PriceList>();
            _productsPriceRetriever = _categoryFilterViewModel == null
                                          ? new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id))
                                          : new ProductsPriceRetriever(
                                                priceListRepository.GetById(_priceListViewModel.Id),
                                                _categoryFilterViewModel.Select(model => model.Id).ToArray());
            _cache = new Cache<ProductsPrice>(_productsPriceRetriever, 100);
            SelectedModel = null;
        }

        public void ShowDetails() {
            var productRepo = _repositoryFactory.CreateRepository<Product>();
            Product product = productRepo.GetById(SelectedModel.ProductId);
            var productUnitsOfMeasure = product.UnitsOfMeasures.ToArray().OrderBy(uom => uom.CountInBaseUnit);

            IDictionary<string, string> details = new Dictionary<string, string> {
                {"Product name", SelectedModel.ProductName}, {
                    "Product price for item",
                    SelectedModel.Price.ToString(CultureInfo.InvariantCulture)
                }
            };

            ProductsUnitOfMeasure baseUnitOfMeasure =
                productUnitsOfMeasure.FirstOrDefault(uom => uom.Base);
            foreach (var productsUnitOfMeasure in productUnitsOfMeasure) {
                if (!productsUnitOfMeasure.Base) {
                    details.Add(productsUnitOfMeasure.UnitOfMeasureName,
                                productsUnitOfMeasure.CountInBaseUnit.ToString(
                                    CultureInfo.InvariantCulture) + " (" +
                                    baseUnitOfMeasure.UnitOfMeasureName + ")");
                }
            }

            if (SelectedModel != null) {
                _view.ShowDetails(details);
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
                               Name = unitOfMeasure.UnitOfMeasureName,
                           }));

                if (SelectedModel.UnitOfMeasureId == 0) {
                    var baseUnitOfMeasure = productUnitsOfMeasure.FirstOrDefault(uom => uom.Base);
                    if (baseUnitOfMeasure != null) {
                        SelectedModel.UnitOfMeasureId = baseUnitOfMeasure.UnitOfMeasureId;
                        SelectedModel.UnitOfMeasureName = baseUnitOfMeasure.UnitOfMeasureName;
                        SelectedModel.CountInUnitOfMeasure = baseUnitOfMeasure.CountInBaseUnit;
                    }
                }
            }

            return unitOfMeasureViewModels;
        }

        public void ChangeUnitOfMeasure(UnitOfMeasureViewModel unitOfMeasureViewModel) {
            if (SelectedModel != null) {
                var productRepository = _repositoryFactory.CreateRepository<Product>();
                var product = productRepository.GetById(SelectedModel.ProductId);
                var productUnitsOfMeasure = product.UnitsOfMeasures.ToArray();
                var productUnitOfMeasure = productUnitsOfMeasure.FirstOrDefault(uom => uom.UnitOfMeasureId == unitOfMeasureViewModel.Id);

                PickUpProductViewModel pickUpProductViewModel =
                    _pickUpProductViewModels.FirstOrDefault(model => model.ProductId == SelectedModel.ProductId);
                if (pickUpProductViewModel != null) {
                    pickUpProductViewModel.UnitOfMeasureId = unitOfMeasureViewModel.Id;
                    pickUpProductViewModel.UnitOfMeasureName = unitOfMeasureViewModel.Name;
                    pickUpProductViewModel.CountInUnitOfMeasure = productUnitOfMeasure.CountInBaseUnit;

                    pickUpProductViewModel.Amount = pickUpProductViewModel.Price *
                                                    pickUpProductViewModel.Quantity *
                                                    (decimal)pickUpProductViewModel.CountInUnitOfMeasure;
                    _view.SetAmount(_pickUpProductViewModels.Sum(model => model.Amount));
                }
                else {
                    SelectedModel.UnitOfMeasureId = unitOfMeasureViewModel.Id;
                    SelectedModel.UnitOfMeasureName = unitOfMeasureViewModel.Name;
                    SelectedModel.CountInUnitOfMeasure = productUnitOfMeasure.CountInBaseUnit;              
                }
            }
        }
    }
}
