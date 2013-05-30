using System;
using MSS.WinMobile.Resources;
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
        private readonly ILocalizator _localizator;
        public Navigator(IViewContainer container, IPresentersFactory presentersFactory, ILocalizator localizator) {
            _container = container;
            _presentersFactory = presentersFactory;
            _localizator = localizator;
        }

        public void GoToLogon() {
            _container.SetView(new LogonView(_presentersFactory, _localizator));
        }

        public void GoToMenu() {
            _container.SetView(new MenuView(_presentersFactory, _localizator));
        }

        public void GoToSettings() {
            _container.SetView(new SettingsView(_presentersFactory, _localizator));
        }

        public void GoToSynchronization(bool autostart)
        {
            _container.SetView(new SynchronizationView(_presentersFactory, _localizator, autostart));
        }

        public void GoToRoute(RouteViewModel routeViewModel) {
            _container.SetView(new RouteView(_presentersFactory, _localizator, routeViewModel));
        }

        public void GoToNewRoutePoint(RouteViewModel routeViewModel) {
            _container.SetView(new NewRoutePointView(_presentersFactory, _localizator, routeViewModel));
        }

        public void GoToChangeStatus(RoutePointViewModel routePointViewModel) {
            _container.SetView(new ChangeStatusView(_presentersFactory, routePointViewModel));
        }

        public void GoToRoutePointsOrderList(RoutePointViewModel routePointViewModel) {
            _container.SetView(new RoutePointsOrderListView(_presentersFactory, _localizator, routePointViewModel));
        }

        public void GoToCreateOrderForRoutePoint(RoutePointViewModel routePointViewModel) {
            _container.SetView(new OrderView(_presentersFactory, _localizator, routePointViewModel));
        }

        public void GoToEditRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel) {
            _container.SetView(new OrderView(_presentersFactory, _localizator, routePointViewModel, orderViewModel));
        }

        public void GoToViewRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel) {
            _container.SetView(new ReadOnlyOrderView(_presentersFactory, _localizator, routePointViewModel, orderViewModel));
        }

        public void GoToOrderList(DateTime date) {
            _container.SetView(new OrderListView(_presentersFactory, _localizator, date));
        }

        public void GoToViewOrder(OrderViewModel orderViewModel) {
            _container.SetView(new ReadOnlyOrderView(_presentersFactory, _localizator, orderViewModel));
        }

        public void GoToEditOrder(OrderViewModel orderViewModel) {
            _container.SetView(new OrderView(_presentersFactory, _localizator, orderViewModel));
        }

        public void GoToExit() {
            _container.Close();
            _container.Dispose();
        }
    }
}
