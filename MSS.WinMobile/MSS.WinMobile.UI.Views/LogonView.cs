using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class LogonView : Form, ILogonView
    {
        private LogonPresenter _presenter;
        private LogonViewModel _viewModel;

        public LogonView()
        {
            InitializeComponent();
        }

        private void ViewLoad(object sender, System.EventArgs e) {
            if (_presenter == null) {
                _presenter = new LogonPresenter(this);
                _viewModel = _presenter.Initialize();
                logonViewModelBindingSource.DataSource = _viewModel;
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

        #endregion

        private void OkButtonClick(object sender, System.EventArgs e) {
            _presenter.Logon();
        }

        private void CancelButtonClick(object sender, System.EventArgs e) {
            _presenter.Cancel();
        }
    }
}