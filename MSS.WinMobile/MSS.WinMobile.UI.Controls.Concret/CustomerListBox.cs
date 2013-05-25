using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.Concret {
    public class CustomerListBox : VirtualListBox {
        public delegate void OnItemInformationNeeded(object sender, VirtualListBoxItem item);

        public event OnItemInformationNeeded ItemInformationNeeded;

        public CustomerListBox() {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem() {
            return new CustomerListBoxItem();
        }

        protected override string EmptyListMessage {
            get { return "Where are no customers."; }
        }

        protected override void AddListBoxItem(VirtualListBoxItem item) {
            base.AddListBoxItem(item);
            var customerListBoxItem = item as CustomerListBoxItem;
            if (customerListBoxItem != null) {
                customerListBoxItem.InformationNeeded += CustomerListBoxItemInformationNeeded;
            }
        }

        private void CustomerListBoxItemInformationNeeded(VirtualListBoxItem item) {
            if (ItemInformationNeeded != null) {
                ItemInformationNeeded.Invoke(this, item);
            }
        }
    }
}
