using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.Concret {
    public class OrderListBox : VirtualListBox {
        public OrderListBox() {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem() {
            return new OrderListBoxItem();
        }

        protected override string EmptyListMessage {
            get { return "Where are no orders."; }
        }
    }
}
