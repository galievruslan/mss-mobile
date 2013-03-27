using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public class ProductPriceListBox : VirtualListBox
    {
        protected override VirtualListBoxItem NewItem()
        {
            return new ProductPriceListBoxItem();
        }
    }
}
