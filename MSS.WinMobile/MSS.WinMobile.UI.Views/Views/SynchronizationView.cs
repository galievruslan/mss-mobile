using System;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class SynchronizationView : View, ISynchronizationView {
        public SynchronizationView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        public SynchronizationView(IPresentersFactory presentersFactory) {
            _presentersFactory = presentersFactory;
            InitializeComponent();
        }

        public SynchronizationViewModel ViewModel { get; private set; }

        private SynchronizationPresenter _synchronizationPresenter;
        private void SynchronizationViewLoad(object sender, EventArgs e) {
            if (_synchronizationPresenter == null) {
                _synchronizationPresenter = _presentersFactory.CreateSynchronizationPresenter(this);
                ViewModel = _synchronizationPresenter.InitializeView();
                ViewModel = ViewModel;

                _synchronizeFullyCheckBox.Checked = ViewModel.SynchronizeFully;
                _lastSyncDateLabel.Text = ViewModel.LastSynchronizationDate != DateTime.MinValue
                                          ? ViewModel.LastSynchronizationDate.ToString(
                                              "dd.MM.yyyy HH:mm")
                                          : "never";
            }
        }

        private void OkButtonClick(object sender, EventArgs e) {
            _synchronizationPresenter.Synchronize();
            _synchronizeFullyCheckBox.Checked = ViewModel.SynchronizeFully;
            _lastSyncDateLabel.Text = ViewModel.LastSynchronizationDate != DateTime.MinValue
                                          ? ViewModel.LastSynchronizationDate.ToString(
                                              "dd.MM.yyyy HH:mm")
                                          : "never";
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            _synchronizationPresenter.Cancel();
        }

        private void SynchronizeFullyCheckBoxCheckStateChanged(object sender, EventArgs e) {
            ViewModel.SynchronizeFully = _synchronizeFullyCheckBox.Checked;
        }
        private delegate void UpdateStatusDelegate(string status);
        public void UpdateStatus(string status) {
            if (_statusLabel.InvokeRequired) {
                _statusLabel.Invoke(new UpdateStatusDelegate(UpdateStatus), status);
            }
            else {
                _statusLabel.Text = status;
            }
        }

        private delegate void ShowProgressBarDelegate();
        public void ShowProgressBar() {
            if (InvokeRequired) {
                Invoke(new ShowProgressBarDelegate(ShowProgressBar));
            }
            else {
                _progressBar.Visible = true;
                _statusLabel.Visible = true;
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
    }
}
