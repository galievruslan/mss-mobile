using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class MenuPresenter
    {
        private readonly IMenuView _view;
        public MenuPresenter(IMenuView view)
        {
            _view = view;
        }

        public void InitializeView()
        {
        }

        public void ShowRouteView() {
            NavigationContext.NavigateTo<IRouteView>();
        }

        public void ShowSyncView() {
            NavigationContext.NavigateTo<ISynchronizationView>();
        }
    }
}
