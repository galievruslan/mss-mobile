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
            ISynchronizationView synchronizationView);

        RoutePresenter CreateRoutePresenter(IRouteView routeView, RouteViewModel routeViewModel);

        NewRoutePointPresenter CreateNewRoutePointPresenter(INewRoutePointView newRoutePointView, RouteViewModel routeViewModel);

        CustomerLookUpPresenter CreateCustomerLookUpPresenter(ICustomerLookUpView customerLookUpView);

        ShippingAddressLookUpPresenter CreateShippingAddressLookUpPresenter(
            IShippingAddressLookUpView shippingAddressLookUpView, CustomerViewModel customerViewModel);

        OrderListPresenter CreateOrderListPresenter(IOrderListView orderListView, RoutePointViewModel routePointViewModel);

        OrderPresenter CreateOrderPresenter(IOrderView orderView, RoutePointViewModel routePointViewModel);

        OrderPresenter CreateOrderPresenter(IOrderView orderView, RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel);

        PriceListLookUpPresenter CreatePriceListLookUpPresenter(IPriceListLookUpView priceListLookUpView);

        WarehouseLookUpPresenter CreateWarehouseLookUpPresenter(IWarehouseLookUpView warehouseLookUpView);

        PickUpProductPresenter CreatePickUpProductPresenter(IPickUpProductView pickUpProductView,
                                                            PriceListViewModel priceListViewModel,
                                                            IEnumerable<OrderItemViewModel> orderItemViewModels);

        SettingsPresenter CreateSettingsPresenter(ISettingsView settingsView);
    }
}
