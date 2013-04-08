using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class MenuPresenter : IPresenter
    {
        private readonly IMenuView _view;

        public MenuPresenter(IMenuView view)
        {
            _view = view;
        }

        public void InitializeView()
        {
            if (ConfigurationManager.AppSettings["ServerUsername"] == string.Empty ||
                ConfigurationManager.AppSettings["ServerPassword"] == string.Empty ||
                ConfigurationManager.AppSettings["ContextManagerId"] == string.Empty)
            {
                NavigationContext.NavigateTo<ILogonView>().ShowView();
            }
            else
            {
                NavigationContext.NavigateTo<IInitializationView>().ShowView();
            }
        }

        public void ShowRouteView()
        {
            NavigationContext.NavigateTo<IRouteView>().ShowView();
        }

        public void ShowSyncView()
        {
            NavigationContext.NavigateTo<ISynchronizationView>().ShowView();
        }
    }
}
