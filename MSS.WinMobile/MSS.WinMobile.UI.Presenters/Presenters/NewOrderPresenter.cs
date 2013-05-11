using System;
using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class NewOrderPresenter : IPresenter<OrderViewModel>, IListPresenter<OrderItemViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(NewOrderPresenter));

        private readonly INewOrderView _view;

        private IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly OrderViewModel _orderViewModel;
        private readonly List<OrderItemViewModel> _orderItemViewModels; 

        public NewOrderPresenter(INewOrderView view, IUnitOfWorkFactory unitOfWorkFactory, IRepositoryFactory repositoryFactory,
            RoutePointViewModel routePointViewModel) {
            _view = view;
            _unitOfWorkFactory = unitOfWorkFactory;
            _repositoryFactory = repositoryFactory;

            var routePointsRepository = _repositoryFactory.CreateRepository<RoutePoint>();
            var routePoint = routePointsRepository.GetById(routePointViewModel.Id);

            var shippingAddressRepository = _repositoryFactory.CreateRepository<ShippingAddress>();
            var shippingAddress = shippingAddressRepository.GetById(routePoint.ShippingAddressId);

            var customersRepository = _repositoryFactory.CreateRepository<Customer>();
            var customer = customersRepository.GetById(shippingAddress.CustomerId);

            _orderViewModel = new OrderViewModel
                {
                    OrderDate = DateTime.Now,
                    ShippingDate = DateTime.Now,
                    RoutePointId = routePoint.Id,
                    CustomerId = customer.Id,
                    CustomerName = customer.Name,
                    ShippingAddressId = shippingAddress.Id,
                    ShippingAddressName = shippingAddress.Address
                };

            _orderItemViewModels = new List<OrderItemViewModel>();
        }

        public void Save()
        {
            if (_orderViewModel.Validate()) {
                throw new NotImplementedException();
                
                _view.CloseView();
                return;
            }

            _view.DisplayErrors(_orderViewModel.Errors);
        }

        public void Cancel()
        {
            _view.CloseView();
        }

        public void PickUpProducts()
        {
        }

        public OrderViewModel Initialize() {
            return _orderViewModel;
        }

        public int InitializeListSize() {
            return _orderItemViewModels.Count;
        }

        public OrderItemViewModel GetItem(int index) {
            return _orderItemViewModels[index];
        }

        private OrderItemViewModel _selectedOrderItemViewModel;
        public void Select(int index) {
            _selectedOrderItemViewModel = _orderItemViewModels[index];
        }

        public OrderItemViewModel SelectedModel {
            get { return _selectedOrderItemViewModel; }
        }

        public void LookUpPriceList()
        {
            var view = NavigationContext.NavigateTo<IPriceListLookUpView>();
            if (view.ShowDialogView() == DialogViewResult.Ok)
            {
                _orderViewModel.PriceListId = view.SelectedPriceList.Id;
                _orderViewModel.PriceListName = view.SelectedPriceList.Name;
            }
            view.CloseView();
        }

        public void ResetPriceList()
        {
            _orderViewModel.PriceListId = 0;
            _orderViewModel.PriceListName = string.Empty;
        }

        public void LookUpWarehouse()
        {
            var view = NavigationContext.NavigateTo<IWarehouseLookUpView>();
            if (view.ShowDialogView() == DialogViewResult.Ok)
            {
                _orderViewModel.WarehouseId = view.SelectedWarehouse.Id;
                _orderViewModel.WarehouseAddress = view.SelectedWarehouse.Address;
            }
            view.CloseView();
        }

        public void ResetWarehouse()
        {
            _orderViewModel.WarehouseId = 0;
            _orderViewModel.WarehouseAddress = string.Empty;
        }
    }
}
