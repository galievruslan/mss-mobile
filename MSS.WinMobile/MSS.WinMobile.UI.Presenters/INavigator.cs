using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Presenters
{
    public interface INavigator {
        void GoToLogon();
        void GoToMenu();
        void GoToSettings();
        void GoToSynchronization(bool autostart);

        void GoToRoute(RouteViewModel routeViewModel);
        void GoToNewRoutePoint(RouteViewModel routeViewModel);

        void GoToRoutePointsOrderList(RoutePointViewModel routePointViewModel);
        void GoToCreateOrderForRoutePoint(RoutePointViewModel routePointViewModel);
        void GoToEditRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel);

        void GoToExit();
    }
}
