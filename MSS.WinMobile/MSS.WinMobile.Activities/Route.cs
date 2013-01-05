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
    public partial class Route : UserControl, IActivity
    {
        public Route()
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
    }
}
