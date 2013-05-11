using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public interface IPresentersFactory {
        LogonPresenter CreateLogonPresenter(ILogonView logonView);

        SynchronizationPresenter CreateSynchronizationPresenter(
            ISynchronizationView synchronizationView);

        RoutePresenter CreateRoutePresenter(IRouteView routeView);

        NewRoutePointPresenter CreateNewRoutePointPresenter(INewRoutePointView newRoutePointView, RouteViewModel routeViewModel);

        CustomerLookUpPresenter CreateCustomerLookUpPresenter(ICustomerLookUpView customerLookUpView);

        ShippingAddressLookUpPresenter CreateShippingAddressLookUpPresenter(
            IShippingAddressLookUpView shippingAddressLookUpView, CustomerViewModel customerViewModel);

        OrderListPresenter CreateOrderListPresenter(IOrderListView orderListView, RoutePointViewModel routePointViewModel);

        NewOrderPresenter CreateNewOrderPresenter(INewOrderView orderView, RoutePointViewModel routePointViewModel);

        PriceListLookUpPresenter CreatePriceListLookUpPresenter(IPriceListLookUpView priceListLookUpView);

        WarehouseLookUpPresenter CreateWarehouseLookUpPresenter(IWarehouseLookUpView warehouseLookUpView);
    }
}
