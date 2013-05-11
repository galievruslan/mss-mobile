using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.Concret {
    public class OrderItemListBox : VirtualListBox {
        public OrderItemListBox() {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem() {
            return new OrderItemListBoxItem();
        }

        protected override string EmptyListMessage {
            get { return "Where are no items."; }
        }
    }
}
