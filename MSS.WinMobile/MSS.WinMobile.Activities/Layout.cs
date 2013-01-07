using System;
using System.Windows.Forms;

namespace MSS.WinMobile.UI.Activities
{
    public partial class Layout : Form, IContainer
    {
        readonly INavigator _navigator;

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
                var control = activity as Control;
                SuspendLayout();
                _pBody.Controls.Clear();
                _pBody.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                ResumeLayout();
            }

            activity.SetNavigator(_navigator);
        }
    }
}