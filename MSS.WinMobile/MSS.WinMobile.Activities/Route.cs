using System.Windows.Forms;

namespace MSS.WinMobile.UI.Activities
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
