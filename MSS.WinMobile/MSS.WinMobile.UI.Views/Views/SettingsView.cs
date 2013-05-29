using System;
using System.Globalization;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class SettingsView : View, ISettingsView {
        public SettingsView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;

        public SettingsView(IPresentersFactory presentersFactory) {
            InitializeComponent();
            _presentersFactory = presentersFactory;
        }

        private SettingsPresenter _settingsPresenter;
        private SettingsViewModel _settingsViewModel;
        private void SettingsViewLoad(object sender, EventArgs e) {
            if (_settingsPresenter == null) {
                _settingsPresenter = _presentersFactory.CreateSettingsPresenter(this);
                _settingsViewModel = _settingsPresenter.Initialize();

                _serverNameTextBox.Text = _settingsViewModel.ServerAddress;
                _accountTextBox.Text = _settingsViewModel.Username;
                _passwordTextBox.Text = _settingsViewModel.Password;
                _batchSizeTextBox.Text =
                    _settingsViewModel.SynchronizationBatchSize.ToString(CultureInfo.InvariantCulture);
                _languagesComboBox.DataSource = _settingsPresenter.GetAvailableLanguages();
                _languagesComboBox.SelectedItem = _settingsPresenter.GetSelectedLocalization();
                _languagesComboBox.SelectedValueChanged += _languagesComboBox_SelectedValueChanged;

                ViewContainer.RegisterLeftAction(new Save(_settingsPresenter));
                ViewContainer.RegisterRightAction(new Cancel(_settingsPresenter));
            }
        }

        private void PasswordTextBoxTextChanged(object sender, EventArgs e) {
            _settingsViewModel.Password = _passwordTextBox.Text;
        }

        private void AccountTextBoxTextChanged(object sender, EventArgs e) {
            _settingsViewModel.Username = _accountTextBox.Text;
        }

        private void ServerNameTextBoxTextChanged(object sender, EventArgs e) {
            _settingsViewModel.ServerAddress = _serverNameTextBox.Text;
        }

        private void LogoutLinkLabelClick(object sender, EventArgs e) {
            _settingsPresenter.Logout();
        }

        private void BatchSizeTextBoxTextChanged(object sender, EventArgs e) {
            try {
                _settingsViewModel.SynchronizationBatchSize = Int32.Parse(_batchSizeTextBox.Text);
            }
            catch {
                _batchSizeTextBox.Text =
                    _settingsViewModel.SynchronizationBatchSize.ToString(CultureInfo.InvariantCulture);
            }
        }

        private class Save : IViewAction {
            private readonly SettingsPresenter _presenter;
            public Save(SettingsPresenter presenter) {
                _presenter = presenter;
            }

            public string Caption {
                get { return "Save"; }
            }
            public void Do(object sender, EventArgs e) {
                _presenter.Save();
            }
        }

        private class Cancel : IViewAction {
            private readonly SettingsPresenter _presenter;
            public Cancel(SettingsPresenter presenter) {
                _presenter = presenter;
            }

            public string Caption {
                get { return "Cancel"; }
            }
            public void Do(object sender, EventArgs e) {
                _presenter.Cancel();
            }
        }

        private void _languagesComboBox_SelectedValueChanged(object sender, EventArgs e) {
            var localizationViewModel = _languagesComboBox.SelectedItem as LocalizationViewModel;
            if (localizationViewModel != null)
                _settingsViewModel.Localization =
                    localizationViewModel.Path;
        }
    }
}
