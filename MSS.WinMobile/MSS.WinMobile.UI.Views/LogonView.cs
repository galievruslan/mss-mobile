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
            logonViewModelBindingSource.EndEdit();
            DialogResult = DialogResult.OK;
            _presenter.Logon();
        }

        private void CancelButtonClick(object sender, System.EventArgs e) {
            DialogResult = DialogResult.Cancel;
            _presenter.Cancel();
        }
    }
}