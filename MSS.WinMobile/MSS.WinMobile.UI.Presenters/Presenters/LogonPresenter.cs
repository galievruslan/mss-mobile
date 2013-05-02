using System.Net;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Infrastructure.WebRepositories;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class LogonPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogonPresenter));

        private readonly Application.Configuration.ConfigurationManager _configurationManager;
        private readonly ILogonView _view;

        public LogonPresenter(ILogonView view)
        {
            _configurationManager = new Application.Configuration.ConfigurationManager(Environments.AppPath);
            _view = view;
        }

        public void Logon()
        {
            if (_viewModel.Validate()) {
                try {
                    var webServer = new WebServer(_viewModel.ServerAddress);
                    using (new WebConnectionFactory(webServer, _viewModel.Username, _viewModel.Password)) {
                        _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Username").Value =
                            _viewModel.Username;
                        _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Password").Value =
                            _viewModel.Password;
                        _configurationManager.GetConfig("Common").Save();
                    }

                    NavigationContext.NavigateTo<IInitializationView>().ShowView();
                    _view.CloseView();
                }
                catch (WebException webException) {
                    Log.Error(webException);
                    _view.DisplayErrors("Can't connect to the server!");
                }
            }
            else {
                _view.DisplayErrors(_viewModel.Errors);
            }
        }

        public void Cancel()
        {
        }

        private LogonViewModel _viewModel;
        public LogonViewModel InitializeView()
        {
            _viewModel = new LogonViewModel
                {
                    ServerAddress =
                        _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Address").Value
                };
            return _viewModel;
        }
    }
}
