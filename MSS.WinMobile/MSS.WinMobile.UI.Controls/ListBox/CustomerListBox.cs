using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public class CustomerListBox : VirtualListBox
    {
        protected override VirtualListBoxItem NewItem()
        {
            return new CustomerListBoxItem();
        }
    }
}
