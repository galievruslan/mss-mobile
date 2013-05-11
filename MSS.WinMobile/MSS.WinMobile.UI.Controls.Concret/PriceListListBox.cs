using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.Concret
{
    public class PriceListListBox : VirtualListBox
    {
        public PriceListListBox()
        {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem()
        {
            return new CustomerListBoxItem();
        }

        protected override string EmptyListMessage {
            get {
                return "Where are no price lists.";
            }
        }
    }
}
