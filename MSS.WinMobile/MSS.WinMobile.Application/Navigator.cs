using System.Collections.Generic;
using MSS.WinMobile.UI.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using MSS.WinMobile.UI.Views;
using MSS.WinMobile.UI.Views.LookUps;
using MSS.WinMobile.UI.Views.Views;

namespace MSS.WinMobile.Application
{
    public class Navigator : INavigator {
        private readonly IViewContainer _container;
        private readonly IPresentersFactory _presentersFactory;
        public Navigator(IViewContainer container, IPresentersFactory presentersFactory) {
            _container = container;
            _presentersFactory = presentersFactory;
        }

        public void NavigateTo<T>(IDictionary<string, object> args) where T : class, IView
        {
            T view = default(T);
            if (typeof (T) == typeof (ILogonView))
            {
                view = (new LogonView(_presentersFactory)) as T;
            }
            else if (typeof(T) == typeof(IMenuView))
            {
                view = (new MenuView(_presentersFactory)) as T;
            }
            else if (typeof(T) == typeof(IExitView))
            {
                _container.Close();
                _container.Dispose();
                return;
            }
            else if (typeof(T) == typeof(ISynchronizationView))
            {
                view = (new SynchronizationView(_presentersFactory)) as T;
            }
            else if (typeof(T) == typeof(IRouteView))
            {
                view = (new RouteView(_presentersFactory)) as T;
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
            else if (typeof(T) == typeof(IOrderView))
            {
                if (args.ContainsKey("route_point")) {
                    var routePointViewModel = args["route_point"] as RoutePointViewModel;
                    view = (new OrderView(_presentersFactory, routePointViewModel)) as T;
                }

                if (args.ContainsKey("order")) {
                    var orderViewModel = args["order"] as OrderViewModel;
                    view = (new OrderView(_presentersFactory, orderViewModel)) as T;
                }
            }
            else if (typeof(T) == typeof(IPickUpProductView))
            {
                var orderViewModel = args["order"] as OrderViewModel;
                var orderItemsViewModel = args["order_items"] as IList<OrderItemViewModel>;
                view = (new PickUpProductView(_presentersFactory, orderViewModel, orderItemsViewModel)) as T;
            }

            _container.SetView(view);
        }
    }
}
