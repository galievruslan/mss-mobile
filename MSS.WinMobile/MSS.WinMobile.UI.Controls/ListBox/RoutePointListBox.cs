using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public class RoutePointListBox : VirtualListBox
    {
        protected override VirtualListBoxItem NewItem()
        {
            return new RoutePointListBoxItem();
        }
    }
}
