using System;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class LogonView : View, ILogonView {
        public LogonView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        public LogonView(IPresentersFactory presentersFactory) {
            InitializeComponent();
            _presentersFactory = presentersFactory;
        }

        private LogonPresenter _logonPresenter;
        private LogonViewModel _viewModel;
        private void LogonViewLoad(object sender, EventArgs e) {
            if (_logonPresenter == null) {
                _logonPresenter = _presentersFactory.CreateLogonPresenter(this);
                _viewModel = _logonPresenter.Initialize();

                _serverTextBox.Text = _viewModel.ServerAddress;
                _accountTextBox.Text = _viewModel.Username;
                _passwordTextBox.Text = _viewModel.Password;
            }
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            _logonPresenter.Cancel();
        }

        private void OkButtonClick(object sender, EventArgs e) {
            _logonPresenter.Logon();
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
    }
}
