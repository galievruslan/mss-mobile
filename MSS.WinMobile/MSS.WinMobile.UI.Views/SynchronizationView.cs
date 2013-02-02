﻿using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class SynchronizationView : Form, ISynchronizationView
    {
        private readonly SynchronizationPresenter _presenter;

        public SynchronizationView()
        {
            InitializeComponent();
            _presenter = new SynchronizationPresenter(this);
        }

        public void NavigateTo<T>() where T : IView
        {
            this.Navigate<T>();
        }

        public void ShowErrorDialog(string message)
        {
            this.ShowErrDialog(message);
        }

        public void ShowInformationDialog(string message)
        {
            this.ShowInfoDialog(message);
        }

        public bool ShowConfirmationDialog(string question)
        {
            return this.ShowConfirmDialog(question);
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
                if (_statusTextBox.Text != string.Empty)
                    _statusTextBox.Text += "\n";

                _statusTextBox.Text += status;
            }
        }

        public void Cancel()
        {
            _presenter.Cancel();
        }

        public void Exit()
        {
            Close();
            Dispose();
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