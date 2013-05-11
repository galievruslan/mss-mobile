using System;
using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Views;

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
                int customerId = Int32.Parse(args["customer_id"].ToString());

                view = (new ShippingAddressLookUpView(_presentersFactory, customerId)) as T;
            }
            else if (typeof(T) == typeof(INewRoutePointView)) {
                int routeId = Int32.Parse(args["route_id"].ToString());
                view = (new NewRoutePointView(_presentersFactory, routeId)) as T;
            }
            else if (typeof(T) == typeof(IOrderListView))
            {
                int routeId = Int32.Parse(args["route_point_id"].ToString());
                view = (new OrderListView(_presentersFactory, routeId)) as T;
            }
            else if (typeof(T) == typeof(IPickUpProductView))
            {
                view = (new PickUpProductView(args)) as T;
            }

            return view;
        }
    }
}
