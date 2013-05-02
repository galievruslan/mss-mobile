using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret
{
    public class RoutePointListBox : VirtualListBox
    {
        public RoutePointListBox() {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem()
        {
            return new RoutePointListBoxItem();
        }
    }
}
