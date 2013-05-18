using System;
using System.Globalization;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Synchronizer.Specifications;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class SettingsPresenter : IPresenter<SettingsViewModel> {
        private readonly ISettingsView _view;
        private IStorageManager _storageManager;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly INavigator _navigator;
        private readonly ConfigurationManager _configurationManager;

        public SettingsPresenter(ISettingsView view, IStorageManager storageManager, IRepositoryFactory repositoryFactory, INavigator navigator) {
            _view = view;
            _storageManager = storageManager;
            _repositoryFactory = repositoryFactory;
            _navigator = navigator;
            _configurationManager = new ConfigurationManager(Environments.AppPath);
        }

        private SettingsViewModel _viewModel;
        public SettingsViewModel Initialize() {
            _viewModel = new SettingsViewModel
                {
                    ServerAddress = _configurationManager.GetConfig("Common")
                                                         .GetSection("Server")
                                                         .GetSetting("Address")
                                                         .Value,
                    Username = _configurationManager.GetConfig("Common")
                                                    .GetSection("Server")
                                                    .GetSetting("Username")
                                                    .Value,
                    Password = _configurationManager.GetConfig("Common")
                                                    .GetSection("Server")
                                                    .GetSetting("Password")
                                                    .Value,
                    SynchronizationBatchSize = _configurationManager.GetConfig("Common")
                                                                    .GetSection("Synchronization")
                                                                    .GetSetting("BathSize")
                                                                    .As<int>()
                };

            return _viewModel;
        }

        public void Save() {
            if (_viewModel.Validate()) {
                _configurationManager.GetConfig("Common")
                                     .GetSection("Server")
                                     .GetSetting("Address")
                                     .Value = _viewModel.ServerAddress;
                _configurationManager.GetConfig("Common")
                                     .GetSection("Server")
                                     .GetSetting("Username").Value = _viewModel.Username;
                _configurationManager.GetConfig("Common")
                                     .GetSection("Server")
                                     .GetSetting("Password").Value = _viewModel.Password;
                _configurationManager.GetConfig("Common")
                                     .GetSection("Synchronization")
                                     .GetSetting("BathSize").Value =
                    _viewModel.SynchronizationBatchSize.ToString(CultureInfo.InvariantCulture);
                _configurationManager.GetConfig("Common").Save();
                _navigator.GoToMenu();
            }
            else {
                _view.ShowError(_viewModel.Errors);
            }
        }

        public void GoToMenu() {
            _navigator.GoToMenu();
        }

        public void Logout() {
            var routeRepository = _repositoryFactory.CreateRepository<Route>();
            var orderRepository = _repositoryFactory.CreateRepository<Order>();
            if (routeRepository.Find().Where(new RoutesToSyncSpec()).Count() > 0 ||
                orderRepository.Find().Where(new OrdersToSyncSpec()).Count() > 0) {
                if (
                    _view.ShowConfirmation(
                        "You have not synchronized data, which will be missed. Are you shure, you want to logout?")) {
                    _storageManager.DeleteCurrentStorage();

                    _configurationManager.GetConfig("Common")
                                         .GetSection("Server")
                                         .GetSetting("Username").Value = string.Empty;
                    _configurationManager.GetConfig("Common")
                                         .GetSection("Server")
                                         .GetSetting("Password").Value = string.Empty;
                    _configurationManager.GetConfig("Common").Save();
                    _navigator.GoToExit();
                }
            }
        }
    }
}
