using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.Concret
{
    public class ProductPriceListBox : NewVirtualListBox
    {
        public ProductPriceListBox()
        {
            InitializeComponent();
        }

        protected override NewVirtualListBoxItem NewItem()
        {
            return new NewProductPriceListBoxItem();
        }

        protected override string EmptyListMessage {
            get {
                return "Where are no products for current price list.";
            }
        }
    }
}
