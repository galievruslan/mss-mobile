using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.ViewModels;

namespace MSS.WinMobile.UI.Controls.Concret
{
    public class RouteListBox : VirtualListBox
    {
        public RouteListBox() {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem()
        {
            return new RouteListBoxItem();
        }
    }
}
