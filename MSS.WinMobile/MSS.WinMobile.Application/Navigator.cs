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
        private readonly ILocalizationManager _localizationManager;
        public Navigator(IViewContainer container, IPresentersFactory presentersFactory, ILocalizationManager localizationManager) {
            _container = container;
            _presentersFactory = presentersFactory;
            _localizationManager = localizationManager;
        }

        public void GoToLogon() {
            _container.SetView(new LogonView(_presentersFactory, _localizationManager));
        }

        public void GoToMenu() {
            _container.SetView(new MenuView(_presentersFactory, _localizationManager));
        }

        public void GoToSettings() {
            _container.SetView(new SettingsView(_presentersFactory, _localizationManager));
        }

        public void GoToSynchronization(bool autostart)
        {
            _container.SetView(new SynchronizationView(_presentersFactory, _localizationManager, autostart));
        }

        public void GoToRoute(RouteViewModel routeViewModel) {
            _container.SetView(new RouteView(_presentersFactory, _localizationManager, routeViewModel));
        }

        public void GoToNewRoutePoint(RouteViewModel routeViewModel) {
            _container.SetView(new NewRoutePointView(_presentersFactory, _localizationManager, routeViewModel));
        }

        public void GoToChangeStatus(RoutePointViewModel routePointViewModel) {
            _container.SetView(new ChangeStatusView(_presentersFactory, routePointViewModel));
        }

        public void GoToRoutePointsOrderList(RoutePointViewModel routePointViewModel) {
            _container.SetView(new RoutePointsOrderListView(_presentersFactory, _localizationManager, routePointViewModel));
        }

        public void GoToCreateOrderForRoutePoint(RoutePointViewModel routePointViewModel) {
            _container.SetView(new OrderView(_presentersFactory, _localizationManager, routePointViewModel));
        }

        public void GoToEditRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel) {
            _container.SetView(new OrderView(_presentersFactory, _localizationManager, routePointViewModel, orderViewModel));
        }

        public void GoToViewRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel) {
            _container.SetView(new ReadOnlyOrderView(_presentersFactory, _localizationManager, routePointViewModel, orderViewModel));
        }

        public void GoToOrderList(DateTime date) {
            _container.SetView(new OrderListView(_presentersFactory, _localizationManager, date));
        }

        public void GoToViewOrder(OrderViewModel orderViewModel) {
            _container.SetView(new ReadOnlyOrderView(_presentersFactory, _localizationManager, orderViewModel));
        }

        public void GoToEditOrder(OrderViewModel orderViewModel) {
            _container.SetView(new OrderView(_presentersFactory, _localizationManager, orderViewModel));
        }

        public void GoToExit() {
            _container.Close();
            _container.Dispose();
        }
    }
}
