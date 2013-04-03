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
                var view = NavigationContext.NavigateTo<ILogonView>();
                view.ShowView();
            }
            else
            {
                var initView = NavigationContext.NavigateTo<IInitializationView>();
                initView.ShowView();
            }
        }
    }
}
