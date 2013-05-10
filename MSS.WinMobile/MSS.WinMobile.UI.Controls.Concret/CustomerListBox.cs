using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.Concret
{
    public class CustomerListBox : VirtualListBox
    {
        public CustomerListBox() {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem()
        {
            return new CustomerListBoxItem();
        }

        protected override string EmptyListMessage {
            get {
                return "Where are no customers.";
            }
        }
    }
}
