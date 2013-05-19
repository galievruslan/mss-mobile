using MSS.WinMobile.UI.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Views;
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

        public void GoToLogon() {
            ILogonView logonView = new LogonView(_presentersFactory);
            _container.SetView(logonView);
        }

        public void GoToMenu() {
            IMenuView menuView = new MenuView(_presentersFactory);
            _container.SetView(menuView);
        }

        public void GoToSettings() {
            ISettingsView settingsView = new SettingsView(_presentersFactory);
            _container.SetView(settingsView);
        }

        public void GoToSynchronization(bool autostart)
        {
            ISynchronizationView synchronizationView = new SynchronizationView(_presentersFactory, autostart);
            _container.SetView(synchronizationView);
        }

        public void GoToRoute(RouteViewModel routeViewModel) {
            IRouteView routeView = new RouteView(_presentersFactory, routeViewModel);
            _container.SetView(routeView);
        }

        public void GoToNewRoutePoint(RouteViewModel routeViewModel) {
            INewRoutePointView newRoutePointView = new NewRoutePointView(_presentersFactory, routeViewModel);
            _container.SetView(newRoutePointView);
        }

        public void GoToRoutePointsOrderList(RoutePointViewModel routePointViewModel) {
            IOrderListView orderListView = new OrderListView(_presentersFactory, routePointViewModel);
            _container.SetView(orderListView);
        }

        public void GoToCreateOrderForRoutePoint(RoutePointViewModel routePointViewModel) {
            IOrderView orderView = new OrderView(_presentersFactory, routePointViewModel);
            _container.SetView(orderView);
        }

        public void GoToEditRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel) {
            IOrderView orderView = new OrderView(_presentersFactory, routePointViewModel, orderViewModel);
            _container.SetView(orderView);
        }

        public void GoViewRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel) {
            IOrderView orderView = new ReadOnlyOrderView(_presentersFactory, routePointViewModel, orderViewModel);
            _container.SetView(orderView);
        }

        public void GoToExit() {
            _container.Close();
            _container.Dispose();
        }
    }
}
