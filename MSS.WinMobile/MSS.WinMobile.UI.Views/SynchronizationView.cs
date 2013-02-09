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
            if (_statusTextBox.InvokeRequired)
            {
                _statusTextBox.Invoke(new UpdateStatusDelegate(UpdateStatus), status);
            }
            else
            {
                _statusTextBox.Text += status;
                _statusTextBox.ScrollToCaret();
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