using System;
using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using MSS.WinMobile.UI.Views;
using MSS.WinMobile.UI.Views.LookUps;

namespace MSS.WinMobile.Application
{
    public class Navigator : INavigator {
        private readonly IPresentersFactory _presentersFactory;
        public Navigator(IPresentersFactory presentersFactory) {
            _presentersFactory = presentersFactory;
        }

        public T NavigateTo<T>(IDictionary<string, object> args) where T : class, IView
        {
            T view = default(T);
            if (typeof (T) == typeof (ILogonView))
            {
                view = (new LogonView(_presentersFactory)) as T;
            }
            else if (typeof(T) == typeof(IMenuView))
            {
                view = (new MenuView()) as T;
            }
            else if (typeof(T) == typeof(IInitializationView))
            {
                view = (new InitializationView()) as T;
            }
            else if (typeof(T) == typeof(ISynchronizationView))
            {
                view = (new SynchronizationView(_presentersFactory)) as T;
            }
            else if (typeof(T) == typeof(IRouteView))
            {
                view = (new RouteView(_presentersFactory)) as T;
            }
            else if (typeof(T) == typeof(ICustomerLookUpView)) {
                view = (new CustomerLookUpView(_presentersFactory)) as T;
            }
            else if (typeof(T) == typeof(IShippingAddressLookUpView)) {
                var customer = args["customer"] as CustomerViewModel;

                view = (new ShippingAddressLookUpView(_presentersFactory, customer)) as T;
            }
            else if (typeof(T) == typeof(INewRoutePointView)) {
                var route = args["route"] as RouteViewModel;
                view = (new NewRoutePointView(_presentersFactory, route)) as T;
            }
            else if (typeof(T) == typeof(IOrderListView))
            {
                var routePointViewModel = args["route_point"] as RoutePointViewModel;
                view = (new OrderListView(_presentersFactory, routePointViewModel)) as T;
            }
            else if (typeof(T) == typeof(INewOrderView))
            {
                var routePointViewModel = args["route_point"] as RoutePointViewModel;
                view = (new OrderView(_presentersFactory, routePointViewModel)) as T;
            }

            return view;
        }
    }
}
