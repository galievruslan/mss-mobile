using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;
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

        public void Logon()
        {
            _presenter.Logon();
        }

        public void Cancel()
        {
            _presenter.Cancel();
        }

        private void OkButtonClick(object sender, System.EventArgs e)
        {
            Logon();
        }

        private void CancelButtonClick(object sender, System.EventArgs e)
        {
            Cancel();
        }

        private void AccountTextBoxTextChanged(object sender, System.EventArgs e) {
            Account = _accountTextBox.Text;
        }

        private void PasswordTextBoxTextChanged(object sender, System.EventArgs e) {
            Password = _passwordTextBox.Text;
        }

        private void LogonView_Load(object sender, System.EventArgs e)
        {
            if (_presenter == null)
            {
                _presenter = new LogonPresenter(this);
                _presenter.InitializeView();
            }
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
    }
}