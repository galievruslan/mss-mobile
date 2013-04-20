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
            var manager = new Application.Configuration.Manager(Context.GetAppPath());
            string userName = manager.GetConfig("Common").GetSection("Server").GetSetting("Username").Value;
            string password = manager.GetConfig("Common").GetSection("Server").GetSetting("Password").Value;
            string managerId = manager.GetConfig("Common").GetSection("ExecutionContext").GetSetting("ManagerId").Value;

            if (string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(managerId))
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
