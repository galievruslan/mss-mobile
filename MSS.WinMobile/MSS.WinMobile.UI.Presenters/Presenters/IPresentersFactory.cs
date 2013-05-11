using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public interface IPresentersFactory {
        LogonPresenter CreateLogonPresenter(ILogonView logonView);

        SynchronizationPresenter CreateSynchronizationPresenter(
            ISynchronizationView synchronizationView);

        RoutePresenter CreateRoutePresenter(IRouteView routeView);

        NewRoutePointPresenter CreateNewRoutePointPresenter(INewRoutePointView newRoutePointView, int routeId);

        CustomerLookUpPresenter CreateCustomerLookUpPresenter(ICustomerLookUpView customerLookUpView);

        ShippingAddressLookUpPresenter CreateShippingAddressLookUpPresenter(
            IShippingAddressLookUpView shippingAddressLookUpView, int customerId);

        OrderListPresenter CreateOrderListPresenter(IOrderListView orderListView, int routePointId);
    }
}
