using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.Concret
{
    public class WarehouseListBox : VirtualListBox
    {
        public WarehouseListBox()
        {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem()
        {
            return new WarehouseListBoxItem();
        }

        protected override string EmptyListMessage {
            get {
                return "Where are no warehouses.";
            }
        }
    }
}
