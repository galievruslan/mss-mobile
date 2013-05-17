using System;
using System.Net;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Infrastructure.Web.Repositories;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class LogonPresenter : IPresenter<LogonViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogonPresenter));

        private readonly Application.Configuration.ConfigurationManager _configurationManager;
        private readonly ILogonView _view;
        private readonly INavigator _navigator;

        public LogonPresenter(ILogonView view, INavigator navigator)
        {
            _configurationManager = new Application.Configuration.ConfigurationManager(Environments.AppPath);
            _view = view;
            _navigator = navigator;
        }

        public void Logon()
        {
            if (_viewModel.Validate()) {
                try {
                    using (
                        new WebServer(_viewModel.ServerAddress, _viewModel.Username,
                                      _viewModel.Password).Connect()) {
                        _configurationManager.GetConfig("Common")
                                             .GetSection("Server")
                                             .GetSetting("Username")
                                             .Value =
                            _viewModel.Username;
                        _configurationManager.GetConfig("Common")
                                             .GetSection("Server")
                                             .GetSetting("Password")
                                             .Value =
                            _viewModel.Password;
                        _configurationManager.GetConfig("Common").Save();
                    }
                    _navigator.GoToMenu();
                }
                catch (NeedLogonException exception) {
                    Log.Error(exception);
                    _view.ShowError("Username or password is wrong!");
                }
                catch (Exception exception) {
                    Log.Error(exception);
                    _view.ShowError("Can't connect to the server!");
                }
            }
            else {
                _view.ShowError(_viewModel.Errors);
            }
        }

        public void Cancel()
        {
            _navigator.GoToExit();
        }

        private LogonViewModel _viewModel;
        public LogonViewModel Initialize() {
            var manager = new Application.Configuration.ConfigurationManager(Environments.AppPath);
            string userName = manager.GetConfig("Common").GetSection("Server").GetSetting("Username").Value;
            string password = manager.GetConfig("Common").GetSection("Server").GetSetting("Password").Value;

            _viewModel = new LogonViewModel {
                ServerAddress =
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Server")
                                         .GetSetting("Address")
                                         .Value,
                Username = userName,
                Password = password
            };
            return _viewModel;
        }
    }
}
