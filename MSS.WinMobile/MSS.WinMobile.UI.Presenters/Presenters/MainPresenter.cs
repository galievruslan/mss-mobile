using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class MainPresenter : IPresenter
    {
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;
        }

        public void InitializeView()
        {

            if (ConfigurationManager.AppSettings["ServerUsername"] == string.Empty ||
                ConfigurationManager.AppSettings["ServerPassword"] == string.Empty ||
                ConfigurationManager.AppSettings["ContextManagerId"] == string.Empty)
            {
                bool loggedIn = false;

                using (var view = NavigationContext.NavigateTo<ILogonView>())
                {
                    if (DialogViewResult.OK == view.ShowDialogView())
                        loggedIn = true;
                }

                if (loggedIn)
                {
                    using (var view = NavigationContext.NavigateTo<IInitializationView>())
                    {
                        view.ShowDialogView();
                    }

                    using (var view = NavigationContext.NavigateTo<IMenuView>())
                    {
                        view.ShowDialogView();
                    }
                }
            }
            else
            {
                using (var view = NavigationContext.NavigateTo<IInitializationView>())
                {
                    view.ShowDialogView();
                }

                using (var view = NavigationContext.NavigateTo<IMenuView>())
                {
                    view.ShowDialogView();
                }
            }

            _view.CloseView();
        }
    }
}
