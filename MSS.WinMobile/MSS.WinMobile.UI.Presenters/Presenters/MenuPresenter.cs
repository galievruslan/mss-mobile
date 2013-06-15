using System;
using System.Diagnostics;
using System.IO;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;
using Environment = MSS.WinMobile.Application.Environment.Environment;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public class MenuPresenter {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MenuPresenter));

        private readonly IMenuView _view;
        private readonly IConfigurationManager _configurationManager;
        private readonly INavigator _navigator;

        public MenuPresenter(IMenuView view, IConfigurationManager configurationManager, INavigator navigator) {
            _view = view;
            _navigator = navigator;
            _configurationManager = configurationManager;
        }

        public void InitializeView() {
        }

        public void ShowRouteView() {
            _navigator.GoToRoute(new RouteViewModel {Date = DateTime.Today});
        }

        public void ShowSyncView() {
            _navigator.GoToSynchronization(false);
        }

        public void ShowSettingsView() {
            _navigator.GoToSettings();
        }

        public void ShowOrderListView() {
            _navigator.GoToOrderList(DateTime.Today);
        }

        public void RunUpdater() {
            try {
                string updaterExecutable = _configurationManager.GetConfig("Common")
                                                                .GetSection("Updates")
                                                                .GetSetting("Updater")
                                                                .Value;

                string updaterPath = Path.Combine(Environment.AppPath, updaterExecutable);
                var updaterProcessStartInfo = new ProcessStartInfo
                    {
                        Arguments =
                            string.Format("\"{0}\" \"{1}\" \"{2}\"",
                                          Environment.AppExecutableName,
                                          Environment.AppVersion,
                                          "MSS"),
                        FileName = updaterPath,
                        UseShellExecute = true
                    };

                var updaterProcess = new Process {StartInfo = updaterProcessStartInfo};
                updaterProcess.Start();
            }
            catch (Exception exception) {
                Log.Error(exception);
                _view.ShowError(new[] {"Can't run updater"});
            }
        }
    }
}
