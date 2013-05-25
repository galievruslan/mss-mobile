using System;
using MSS.WinMobile.UI.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
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
            _container.SetView(new LogonView(_presentersFactory));
        }

        public void GoToMenu() {
            _container.SetView(new MenuView(_presentersFactory));
        }

        public void GoToSettings() {
            _container.SetView(new SettingsView(_presentersFactory));
        }

        public void GoToSynchronization(bool autostart)
        {
            _container.SetView(new SynchronizationView(_presentersFactory, autostart));
        }

        public void GoToRoute(RouteViewModel routeViewModel) {
            _container.SetView(new RouteView(_presentersFactory, routeViewModel));
        }

        public void GoToNewRoutePoint(RouteViewModel routeViewModel) {
            _container.SetView(new NewRoutePointView(_presentersFactory, routeViewModel));
        }

        public void GoToChangeStatus(RoutePointViewModel routePointViewModel) {
            _container.SetView(new ChangeStatusView(_presentersFactory, routePointViewModel));
        }

        public void GoToRoutePointsOrderList(RoutePointViewModel routePointViewModel) {
            _container.SetView(new RoutePointsOrderListView(_presentersFactory, routePointViewModel));
        }

        public void GoToCreateOrderForRoutePoint(RoutePointViewModel routePointViewModel) {
            _container.SetView(new OrderView(_presentersFactory, routePointViewModel));
        }

        public void GoToEditRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel) {
            _container.SetView(new OrderView(_presentersFactory, routePointViewModel, orderViewModel));
        }

        public void GoToViewRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel) {
            _container.SetView(new ReadOnlyOrderView(_presentersFactory, routePointViewModel, orderViewModel));
        }

        public void GoToOrderList(DateTime date) {
            _container.SetView(new OrderListView(_presentersFactory, date));
        }

        public void GoToViewOrder(OrderViewModel orderViewModel) {
            _container.SetView(new ReadOnlyOrderView(_presentersFactory, orderViewModel));
        }

        public void GoToEditOrder(OrderViewModel orderViewModel) {
            _container.SetView(new OrderView(_presentersFactory, orderViewModel));
        }

        public void GoToExit() {
            _container.Close();
            _container.Dispose();
        }
    }
}
