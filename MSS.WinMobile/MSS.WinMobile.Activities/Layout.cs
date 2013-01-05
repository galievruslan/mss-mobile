using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MSS.WinMobile.Activities
{
    public partial class Layout : Form, IContainer
    {
        INavigator _navigator;

        public Layout()
        {
            InitializeComponent();
            _navigator = new Navigator(this);
            _navigator.NavigateTo("Home");
        }

        private void _pbHome_Click(object sender, EventArgs e)
        {
            _navigator.NavigateTo("Home");
        }

        public void Register(IActivity activity) {
            if (activity is Control)
            {
                Control control = activity as Control;
                this.SuspendLayout();
                this._pBody.Controls.Clear();
                this._pBody.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                this.ResumeLayout();
            }

            activity.SetNavigator(_navigator);
        }
    }
}