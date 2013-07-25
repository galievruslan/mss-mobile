using System;
using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public interface IPresentersFactory {
        LogonPresenter CreateLogonPresenter(ILogonView logonView);

        MenuPresenter CreateMenuPresenter(IMenuView logonView);

        SynchronizationPresenter CreateSynchronizationPresenter(
            ISynchronizationView synchronizationView, bool exitOnError);

        RoutePresenter CreateRoutePresenter(IRouteView routeView, RouteViewModel routeViewModel);

        NewRoutePointPresenter CreateNewRoutePointPresenter(INewRoutePointView newRoutePointView, RouteViewModel routeViewModel);

        ChangeStatusPresenter CreateChangeStatusPresenter(IChangeStatusView changeStatusView,
                                                          RoutePointViewModel routePointViewModel);

        CustomerLookUpPresenter CreateCustomerLookUpPresenter(ICustomerLookUpView customerLookUpView);

        ShippingAddressLookUpPresenter CreateShippingAddressLookUpPresenter(
            IShippingAddressLookUpView shippingAddressLookUpView, CustomerViewModel customerViewModel);

        RoutePointsOrderListPresenter CreateRoutePointsOrderListPresenter(IRoutePointsOrderListView orderListView, RoutePointViewModel routePointViewModel);

        OrderListPresenter CreateOrderListPresenter(IOrderListView orderListView);

        OrderPresenter CreateOrderPresenter(IOrderView orderView, RoutePointViewModel routePointViewModel);

        OrderPresenter CreateOrderPresenter(IOrderView orderView, RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel);

        OrderPresenter CreateOrderPresenter(IOrderView orderView, OrderViewModel orderViewModel);

        PriceListLookUpPresenter CreatePriceListLookUpPresenter(IPriceListLookUpView priceListLookUpView);

        WarehouseLookUpPresenter CreateWarehouseLookUpPresenter(IWarehouseLookUpView warehouseLookUpView);

        CategoryLookUpPresenter CreateCategoryLookUpPresenter(ICategoryLookUpView categoryLookUpView, CategoryViewModel selectedViewModel);

        PickUpProductPresenter CreatePickUpProductPresenter(IPickUpProductView pickUpProductView,
                                                            PriceListViewModel priceListViewModel,
                                                            IEnumerable<OrderItemViewModel> orderItemViewModels);

        SettingsPresenter CreateSettingsPresenter(ISettingsView settingsView);
    }
}
