using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public class ShippingAddressListBox : VirtualListBox<ShippingAddress>
    {
        protected override VirtualListBoxItem<ShippingAddress> NewItem()
        {
            return new ShippingAddressListBoxItem();
        }
    }
}
