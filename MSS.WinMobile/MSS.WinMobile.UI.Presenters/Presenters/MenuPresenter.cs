using System;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class MenuPresenter
    {
        private readonly IMenuView _view;
        private readonly INavigator _navigator;
        public MenuPresenter(IMenuView view, INavigator navigator)
        {
            _view = view;
            _navigator = navigator;
        }

        public void InitializeView()
        {
        }

        public void ShowRouteView() {
            _navigator.GoToRoute(new RouteViewModel {Date = DateTime.Today});
        }

        public void ShowSyncView() {
            _navigator.GoToSynchronization();
        }
    }
}
