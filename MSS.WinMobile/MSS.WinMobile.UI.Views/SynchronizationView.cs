using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class SynchronizationView : Form, ISynchronizationView {
        private readonly PresentersFactory _presentersFactory;
        private SynchronizationPresenter _presenter;
        
        public SynchronizationView(PresentersFactory presentersFactory) {
            _presentersFactory = presentersFactory;
            InitializeComponent();
        }

        public SynchronizationViewModel ViewModel { get; private set; }

        private delegate void UpdateStatusDelegate(string status);
        public void UpdateStatus(string status) {
            if (_statusLabel.InvokeRequired) {
                _statusLabel.Invoke(new UpdateStatusDelegate(UpdateStatus), status);
            }
            else {
                _statusLabel.Text = status;
            }
        }

        private delegate void UpdateProgressDelegate(int percents);
        public void UpdateProgress(int percents) {
            if (_progressBar.InvokeRequired) {
                _progressBar.Invoke(new UpdateProgressDelegate(UpdateProgress), percents);
            }
            else {
                _progressBar.Value = percents;
            }
        }

        private void ViewLoad(object sender, EventArgs e) {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateSynchronizationPresenter(this);
                ViewModel = _presenter.InitializeView();
                synchronizationViewModelBindingSource.DataSource = ViewModel;
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
        }

        public void DisplayErrors(string error) {
            notification.Text = error;
            notification.Critical = true;
            notification.Visible = true;
        }

        #endregion

        private void OkButtonClick(object sender, EventArgs e)
        {
            _presenter.Synchronize();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            _presenter.Cancel();
        }
    }
}