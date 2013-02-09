using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class LogonView : UserControl, ILogonView
    {
        private readonly ILayout _layout;
        private readonly LogonPresenter _presenter;

        // Designer only usage
        internal LogonView()
        {
            InitializeComponent();
        }

        public LogonView(ILayout layout)
        {
            InitializeComponent();
            _layout = layout;
            _presenter = new LogonPresenter(layout, this);
        }

        public string Account { get; set; }
        public string Password { get; set; }

        public void NavigateToMainMenu()
        {
            _layout.Navigate<IMenuView>();
        }

        public void Logon()
        {
            _presenter.Logon();
        }

        public void Cancel()
        {
            _presenter.Cancel();
        }

        public void Exit()
        {
            _layout.Exit();
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
    }
}