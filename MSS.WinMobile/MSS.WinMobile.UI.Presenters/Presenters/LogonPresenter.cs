using System;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Infrastructure.Web.Repositories;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;
using Environment = MSS.WinMobile.Application.Environment.Environment;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class LogonPresenter : IPresenter<LogonViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogonPresenter));

        private readonly IConfigurationManager _configurationManager;
        private readonly ILogonView _view;
        private readonly INavigator _navigator;

        public LogonPresenter(ILogonView view, IConfigurationManager configurationManager, INavigator navigator)
        {
            _configurationManager = configurationManager;
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
                                             .GetSetting("Address")
                                             .Value =
                            _viewModel.ServerAddress;
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
                    _navigator.GoToSynchronization(true);
                }
                catch (NeedLogonException exception) {
                    Log.Error(exception);
                    _view.ShowError(new[] {"Username or password is wrong!"});
                }
                catch (Exception exception) {
                    Log.Error(exception);
                    _view.ShowError(new[] {"Can't connect to the server!"});
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
            string userName = _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Username").Value;
            string password = _configurationManager.GetConfig("Common").GetSection("Server").GetSetting("Password").Value;

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
