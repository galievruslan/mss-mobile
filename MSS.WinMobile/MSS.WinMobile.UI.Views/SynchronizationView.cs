using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

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

        private void StartButtonClick(object sender, EventArgs e)
        {
            _presenter.Synchronize();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            _presenter.Cancel();
        }

        private void SynchronizationView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _presenter = new SynchronizationPresenter(this);
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