﻿using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views.Layouts
{
    public partial class Layout : Form, ILayout
    {
        public Layout()
        {
            InitializeComponent();
            _currentView = new LogonView(this) {Dock = DockStyle.Fill};
            _bodyPanel.Controls.Add(_currentView);
        }

        private UserControl _currentView;

        public delegate void NavigateDelegate<T>();
        public void Navigate<T>()
        {
            if (_bodyPanel.InvokeRequired)
            {
                _bodyPanel.Invoke(new NavigateDelegate<T>(Navigate<T>));
            }
            else
            {
                UserControl to;
                if (typeof (T) == typeof (ILogonView))
                    to = new LogonView(this);
                else if (typeof (T) == typeof (IMenuView))
                    to = new MenuView(this);
                else if (typeof (T) == typeof (ISynchronizationView))
                    to = new SynchronizationView(this);
                else if (typeof (T) == typeof (ICustomersView))
                    to = new CustomersView(this);
                else
                    throw new ViewNotFoundException();

                if (_currentView != null)
                {
                    if (_bodyPanel.Controls.Contains(_currentView))
                        _bodyPanel.Controls.Remove(_currentView);

                    _currentView.Dispose();
                }

                _currentView = to;
                _currentView.Dock = DockStyle.Fill;
                _bodyPanel.Controls.Add(_currentView);

                _bodyPanel.Refresh();
            }
        }

        public void ShowInfoDialog(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button1);
        }

        public void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
        }

        public bool ShowConfirmDialog(string question)
        {
            DialogResult dialogResult = MessageBox.Show(question, "Confirmation", MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2);
            return dialogResult == DialogResult.Yes;
        }

        public void Exit()
        {
            Close();
            Dispose();
        }

        public class ViewNotFoundException : Exception
        {
        }
    }
}