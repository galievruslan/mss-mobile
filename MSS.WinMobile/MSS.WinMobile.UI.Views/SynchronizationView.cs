using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class SynchronizationView : UserControl, ISynchronizationView
    {
        private readonly SynchronizationPresenter _presenter;

        // Designer only usage
        internal SynchronizationView()
        {
            InitializeComponent();
        }

        public SynchronizationView(ILayout layout)
        {
            InitializeComponent();
            _presenter = new SynchronizationPresenter(layout, this);
        }

        public void Start()
        {
            _presenter.Synchronize();
        }

        public delegate void UpdateStatusDelegate(string status);
        public void UpdateStatus(string status)
        {
            if (_statusLabel.InvokeRequired)
            {
                _statusLabel.Invoke(new UpdateStatusDelegate(UpdateStatus), status);
            }
            else
            {
                _statusLabel.Text = status;
            }
        }

        public delegate void UpdateProgressDelegate(int percents);
        public void UpdateProgress(int percents)
        {
            if (_progressBar.InvokeRequired)
            {
                _progressBar.Invoke(new UpdateProgressDelegate(UpdateProgress), percents);
            }
            else
            {
                _progressBar.Value = percents;
            }
        }

        public void Cancel()
        {
            _presenter.Cancel();
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            Start();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}