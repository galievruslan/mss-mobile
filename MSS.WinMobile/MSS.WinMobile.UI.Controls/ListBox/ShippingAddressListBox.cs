using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public class ShippingAddressListBox : VirtualListBox
    {
        protected override VirtualListBoxItem NewItem()
        {
            return new ShippingAddressListBoxItem();
        }
    }
}
