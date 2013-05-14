using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class LogonView : Form, ILogonView {
        private readonly IPresentersFactory _presentersFactory;
        private LogonPresenter _presenter;
        private LogonViewModel _viewModel;

        public LogonView(IPresentersFactory presentersFactory)
        {
            InitializeComponent();
            _presentersFactory = presentersFactory;
        }

        private void ViewLoad(object sender, System.EventArgs e) {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateLogonPresenter(this);
                _viewModel = _presenter.Initialize();

                _accountTextBox.Text = _viewModel.Username;
                _passwordTextBox.Text = _viewModel.Password;
            }
        }

        #region IView

        public void ShowView() {
            Show();
        }

        public DialogViewResult ShowDialogView() {
            DialogResult dialogResult = ShowDialog();
            if (dialogResult == DialogResult.OK)
                return DialogViewResult.Ok;

            return DialogViewResult.Cancel;
        }

        public void CloseView() {
            Close();
            Dispose();
        }

        public void DisplayErrors(string error) {
            notification.Text = error;
            notification.Critical = true;
            notification.Visible = true;
        }

        public void HideView() {
            Hide();
        }

        #endregion

        private void OkButtonClick(object sender, System.EventArgs e) {
            if (_presenter.Logon())
                DialogResult = DialogResult.OK;
        }

        private void CancelButtonClick(object sender, System.EventArgs e) {
            DialogResult = DialogResult.Cancel;
            _presenter.Cancel();
        }

        private void AccountTextBoxTextChanged(object sender, System.EventArgs e) {
            _viewModel.Username = _accountTextBox.Text;
        }

        private void PasswordTextBoxTextChanged(object sender, System.EventArgs e) {
            _viewModel.Password = _passwordTextBox.Text;
        }

        private void LogonView_KeyPress(object sender, KeyPressEventArgs e) {
        }
    }
}