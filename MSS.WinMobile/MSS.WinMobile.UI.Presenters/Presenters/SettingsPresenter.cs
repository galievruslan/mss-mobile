using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using MSS.WinMobile.Application.Configuration;
using MSS.WinMobile.Application.Environment;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Resources;
using MSS.WinMobile.Synchronizer.Specifications;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class SettingsPresenter : IPresenter<SettingsViewModel> {
        private readonly ISettingsView _view;
        private readonly IStorageManager _storageManager;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly INavigator _navigator;
        private readonly ConfigurationManager _configurationManager;
        private ILocalizator _localizator;

        public SettingsPresenter(ISettingsView view, IStorageManager storageManager, IRepositoryFactory repositoryFactory, INavigator navigator, ILocalizator localizator) {
            _view = view;
            _storageManager = storageManager;
            _repositoryFactory = repositoryFactory;
            _navigator = navigator;
            _configurationManager = new ConfigurationManager(Environments.AppPath);
            _localizator = localizator;
        }

        private SettingsViewModel _viewModel;
        public SettingsViewModel Initialize() {
            _viewModel = new SettingsViewModel {
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
                                                                .As<int>(),
                Localization = _configurationManager.GetConfig("Common")
                                                    .GetSection("Localization")
                                                    .GetSetting("Current")
                                                    .Value,
            };

            return _viewModel;
        }

        private IEnumerable<LocalizationViewModel> _localizationViewModels;
        public IEnumerable<LocalizationViewModel> GetAvailableLanguages() {
            if (_localizationViewModels == null) {
                var localizations =
                    _localizator.GetAvailableLocalizations(Environments.AppPath);
                _localizationViewModels = localizations.Select(localization => new LocalizationViewModel {
                    Name = localization.Name,
                    Path = localization.Path
                }).ToList();
            }

            return _localizationViewModels;
        }

        public LocalizationViewModel GetSelectedLocalization() {
            var selectedLocalizationViewModel =
                GetAvailableLanguages().FirstOrDefault(
                    model => model.Path == _viewModel.Localization) ??
                GetAvailableLanguages().FirstOrDefault(
                        model => model.Path == _localizator.Localization.Path);

            return selectedLocalizationViewModel;
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
                _configurationManager.GetConfig("Common")
                                     .GetSection("Localization")
                                     .GetSetting("Current")
                                     .Value = _viewModel.Localization;
                _configurationManager.GetConfig("Common").Save();

                List<ILocalization> localizations =
                    _localizator.GetAvailableLocalizations(Environments.AppPath);
                ILocalization current =
                    localizations.FirstOrDefault(
                        l => l.Path.ToUpper() == _viewModel.Localization.ToUpper());
                _localizator.SetupLocalization(current);

                _navigator.GoToMenu();
            }
            else {
                _view.ShowError(_viewModel.Errors);
            }
        }

        public void Cancel() {
            _navigator.GoToMenu();
        }

        public void Logout() {
            var routeRepository = _repositoryFactory.CreateRepository<Route>();
            var orderRepository = _repositoryFactory.CreateRepository<Order>();
            if (routeRepository.Find().Where(new RoutesToSyncSpec()).GetCount() > 0 ||
                orderRepository.Find().Where(new OrdersToSyncSpec()).GetCount() > 0) {
                if (!_view.ShowConfirmation(
                        "You have not synchronized data, which will be missed. Are you shure, you want to logout?")) 
                    return;
            }

            _storageManager.DeleteCurrentStorage();

            _configurationManager.GetConfig("Common")
                                 .GetSection("Server")
                                 .GetSetting("Username").Value = string.Empty;
            _configurationManager.GetConfig("Common")
                                 .GetSection("Server")
                                 .GetSetting("Password").Value = string.Empty;
            _configurationManager.GetConfig("Common")
                                         .GetSection("Synchronization")
                                         .GetSetting("LastSyncDate").Value = string.Empty;
            _configurationManager.GetConfig("Common").Save();
            _navigator.GoToExit();
        }
    }
}
