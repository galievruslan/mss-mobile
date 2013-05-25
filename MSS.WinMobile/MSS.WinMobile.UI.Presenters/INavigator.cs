using System;
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
        void GoToChangeStatus(RoutePointViewModel routePointViewModel);

        void GoToRoutePointsOrderList(RoutePointViewModel routePointViewModel);
        void GoToCreateOrderForRoutePoint(RoutePointViewModel routePointViewModel);
        void GoToEditRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel);
        void GoToViewRoutePointsOrder(RoutePointViewModel routePointViewModel, OrderViewModel orderViewModel);

        void GoToOrderList(DateTime date);
        void GoToViewOrder(OrderViewModel orderViewModel);
        void GoToEditOrder(OrderViewModel orderViewModel);

        void GoToExit();
    }
}
