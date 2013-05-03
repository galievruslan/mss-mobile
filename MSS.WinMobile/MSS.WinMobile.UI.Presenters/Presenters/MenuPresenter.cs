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
            var manager = new Application.Configuration.ConfigurationManager(Environments.AppPath);
            string userName = manager.GetConfig("Common").GetSection("Server").GetSetting("Username").Value;
            string password = manager.GetConfig("Common").GetSection("Server").GetSetting("Password").Value;

            if (string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(password))
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
            NavigationContext.NavigateTo<IRouteListView>().ShowView();
        }

        public void ShowSyncView()
        {
            NavigationContext.NavigateTo<ISynchronizationView>().ShowView();
        }
    }
}
