using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.Concret
{
    public class ProductPriceListBox : VirtualListBox
    {
        public ProductPriceListBox()
        {
            InitializeComponent();
        }

        protected override VirtualListBoxItem NewItem()
        {
            return new ProductPriceListBoxItem();
        }

        protected override string EmptyListMessage {
            get {
                return "Where are no products for current price list.";
            }
        }
    }
}
