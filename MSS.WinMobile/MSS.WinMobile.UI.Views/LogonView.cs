﻿using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class LogonView : Form, ILogonView
    {
        readonly LogonPresenter _presenter;

        public LogonView()
        {
            InitializeComponent();
            _presenter = new LogonPresenter(this);
        }

        public void NavigateTo<T>() where T : IView
        {
            this.Navigate<T>();
        }

        public void ShowInformationDialog(string message)
        {
            this.ShowInfoDialog(message);
        }

        public bool ShowConfirmationDialog(string question)
        {
            return this.ShowConfirmDialog(question);
        }

        public string Account { get; set; }
        public string Password { get; set; }

        public void Logon()
        {
            _presenter.Logon();
        }

        public void Cancel()
        {
            _presenter.Cancel();
        }
    }
}