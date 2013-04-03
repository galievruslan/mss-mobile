using System;
using System.ComponentModel;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class InitializationView : Form, IInitializationView
    {
        private InitializationPresenter _presenter;

        public InitializationView()
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

        private void SynchronizationView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _presenter = new InitializationPresenter(this);
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

        public delegate void CloseViewDelegate();
        public void CloseView()
        {
            if (InvokeRequired)
            {
                Invoke(new CloseViewDelegate(CloseView));
            }
            else
            {
                Close();
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

        #endregion
    }
}