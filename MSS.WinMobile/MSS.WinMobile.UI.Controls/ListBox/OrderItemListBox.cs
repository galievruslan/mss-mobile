using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public class OrderItemListBox : VirtualListBox<OrderItem>
    {
        protected override VirtualListBoxItem<OrderItem> NewItem()
        {
            return new OrderItemListBoxItem();
        }
    }
}
