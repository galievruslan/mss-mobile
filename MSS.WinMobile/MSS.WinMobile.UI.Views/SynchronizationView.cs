using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class SynchronizationView : Form, ISynchronizationView
    {
        private SynchronizationPresenter _presenter;

        // Designer only usage
        public SynchronizationView()
        {
            InitializeComponent();
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

        private void SynchronizationView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _presenter = new SynchronizationPresenter(this);
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