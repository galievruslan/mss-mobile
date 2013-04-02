using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class LogonView : Form, ILogonView
    {
        private LogonPresenter _presenter;

        public LogonView()
        {
            InitializeComponent();
        }

        public string Account { get; set; }
        public string Password { get; set; }


        private void OkButtonClick(object sender, System.EventArgs e)
        {
            _presenter.Logon();
        }

        private void CancelButtonClick(object sender, System.EventArgs e)
        {
            _presenter.Cancel();
        }

        private void AccountTextBoxTextChanged(object sender, System.EventArgs e) {
            Account = _accountTextBox.Text;
        }

        private void PasswordTextBoxTextChanged(object sender, System.EventArgs e) {
            Password = _passwordTextBox.Text;
        }

        private void ViewLoad(object sender, System.EventArgs e)
        {
            if (_presenter == null)
            {
                _presenter = new LogonPresenter(this);
                _presenter.InitializeView();
            }
        }

        #region IView

        public void ShowView()
        {
            Show();
        }

        public DialogViewResult ShowDialogView()
        {
            DialogResult dialogResult = ShowDialog();
            if (dialogResult == DialogResult.OK)
                return DialogViewResult.OK;

            return DialogViewResult.Cancel;
        }

        public void CloseView()
        {
            Close();
        }

        public delegate void DisplayErrorsDelegate(string error);
        public void DisplayErrors(string error)
        {
            if (_errorsLabel.InvokeRequired)
            {
                _errorsLabel.Invoke(new DisplayErrorsDelegate(DisplayErrors), error);
            }
            else
            {
                _errorsLabel.Text = error;
            }
        }

        #endregion
    }
}