using System.Net;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Infrastructure.WebRepositories;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class LogonPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogonPresenter));

        private readonly Application.Configuration.ConfigurationManager _configurationManager;
        private readonly ILogonView _view;
        private readonly WebConnectionFactory _webConnectionFactory;

        public LogonPresenter(ILogonView view, WebConnectionFactory webConnectionFactory)
        {
            _configurationManager = new Application.Configuration.ConfigurationManager(Environments.AppPath);
            _webConnectionFactory = webConnectionFactory;
            _view = view;
        }

        public void Logon()
        {
            string serverAddress = _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Address").Value;

            if (string.IsNullOrEmpty(_view.Account)) {
                _view.DisplayErrors("Account can't be empty!");
                return;
            }

            if (string.IsNullOrEmpty(_view.Password)) {
                _view.DisplayErrors("Password can't be empty!");
                return;
            }

            try {
                if (_webConnectionFactory.CurrentConnection != null) {
                    _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Username").Value =
                        _view.Account;
                    _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Password").Value =
                        _view.Password;
                    _configurationManager.GetConfig("Common").Save();
                    NavigationContext.NavigateTo<IInitializationView>().ShowView();
                    _view.CloseView();
                }
            }
            catch (WebException webException) {
                Log.Error(webException);
                _view.DisplayErrors("Can't connect to the server!");
            }
        }

        public void Cancel()
        {
        }

        public void InitializeView()
        {
            
        }
    }
}
