using System;
using System.Diagnostics;
using System.IO;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Synchronizer.Specifications;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;
using Environment = MSS.WinMobile.Application.Environment.Environment;

namespace MSS.WinMobile.UI.Presenters.Presenters {
    public class MenuPresenter {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MenuPresenter));

        private readonly IMenuView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IConfigurationManager _configurationManager;
        private readonly INavigator _navigator;

        public MenuPresenter(IMenuView view, IRepositoryFactory repositoryFactory, IConfigurationManager configurationManager, INavigator navigator) {
            _view = view;
            _repositoryFactory = repositoryFactory;
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
                IStorageRepository<Route> routeRepository =
                    _repositoryFactory.CreateRepository<Route>();
                int routesToSyncCount =
                    routeRepository.Find().Where(new RoutesToSyncSpec()).GetCount();

                IStorageRepository<Order> orderRepository =
                    _repositoryFactory.CreateRepository<Order>();
                int ordersToSyncCount =
                    orderRepository.Find().Where(new OrdersToSyncSpec()).GetCount();

                if (routesToSyncCount > 0 || ordersToSyncCount > 0) {
                    _view.ShowInformation(
                        "you must synchronize device before update.");
                    return;
                }

                string updaterExecutable = _configurationManager.GetConfig("Common")
                                                                .GetSection("Updates")
                                                                .GetSetting("Updater")
                                                                .Value;

                string updaterPath = Path.Combine(Environment.AppPath, updaterExecutable);
                var updaterProcessStartInfo = new ProcessStartInfo
                    {
                        Arguments =
                            string.Format("\"{0}\" \"{1}\"",
                                          Environment.AppExecutableName,
                                          Environment.AppVersion),
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
