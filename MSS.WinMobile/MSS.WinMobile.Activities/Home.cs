using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MSS.WinMobile.Activities
{
    public partial class Home : UserControl, IActivity
    {
        public Home()
        {
            InitializeComponent();
        }

        #region IActivity Members

        INavigator _navigator;

        public void SetNavigator(INavigator navigator)
        {
            _navigator = navigator;
        }

        #endregion

        private void _lwHome_ItemActivate(object sender, EventArgs e)
        {
            int index = _lwHome.SelectedIndices[0];
            ListViewItem selectedItem = _lwHome.Items[index];
            _navigator.NavigateTo(selectedItem.Text);
        }
    }
}
