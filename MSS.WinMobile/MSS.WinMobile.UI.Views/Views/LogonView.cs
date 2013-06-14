using System;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class LogonView : View, ILogonView {
        public LogonView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private readonly ILocalizationManager _localizationManager;
        public LogonView(IPresentersFactory presentersFactory, ILocalizationManager localizationManager) : this() {
            _presentersFactory = presentersFactory;
            _localizationManager = localizationManager;

            _accountLabel.Text = _localizationManager.Localization.GetLocalizedValue(_accountLabel.Text);
            _passwordLabel.Text = _localizationManager.Localization.GetLocalizedValue(_passwordLabel.Text);
            _serverLabel.Text = _localizationManager.Localization.GetLocalizedValue(_serverLabel.Text);
        }

        private LogonPresenter _logonPresenter;
        private LogonViewModel _viewModel;
        private void LogonViewLoad(object sender, EventArgs e) {
            if (_logonPresenter == null) {
                _logonPresenter = _presentersFactory.CreateLogonPresenter(this);
                _viewModel = _logonPresenter.Initialize();

                ViewContainer.RegisterLeftAction(new Logon(_logonPresenter));
                ViewContainer.RegisterRightAction(new Cancel(_logonPresenter));

                _serverTextBox.Text = _viewModel.ServerAddress;
                _accountTextBox.Text = _viewModel.Username;
                _passwordTextBox.Text = _viewModel.Password;
            }
        }

        private void PasswordTextBoxTextChanged(object sender, EventArgs e) {
            _viewModel.Password = _passwordTextBox.Text;
        }

        private void AccountTextBoxTextChanged(object sender, EventArgs e) {
            _viewModel.Username = _accountTextBox.Text;
        }

        private void ServerTextBoxTextChanged(object sender, EventArgs e) {
            _viewModel.ServerAddress = _serverTextBox.Text;
        }

        private class Logon : IViewAction {
            private readonly LogonPresenter _logonPresenter;
            public Logon(LogonPresenter logonPresenter) {
                _logonPresenter = logonPresenter;
            }

            public string Caption {
                get { return "Logon"; }
            }
            public void Do(object sender, EventArgs e) {
                _logonPresenter.Logon();
            }
        }

        private class Cancel : IViewAction
        {
            private readonly LogonPresenter _logonPresenter;
            public Cancel(LogonPresenter logonPresenter)
            {
                _logonPresenter = logonPresenter;
            }

            public string Caption
            {
                get { return "Cancel"; }
            }
            public void Do(object sender, EventArgs e)
            {
                _logonPresenter.Cancel();
            }
        }
    }
}
