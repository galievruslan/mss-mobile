using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.Concret
{
    public class ShippingAddressListBox : VirtualListBox
    {
        public ShippingAddressListBox() {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem()
        {
            return new ShippingAddressListBoxItem();
        }

        protected override string EmptyListMessage {
            get {
                return "Where are no shipping addresses.";
            }
        }
    }
}
