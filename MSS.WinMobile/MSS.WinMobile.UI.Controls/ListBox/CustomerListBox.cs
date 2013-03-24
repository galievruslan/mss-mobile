using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;

namespace MSS.WinMobile.UI.Controls.ListBox
{
    public class CustomerListBox : VirtualListBox<Customer>
    {
        protected override VirtualListBoxItem<Customer> NewItem()
        {
            return new CustomerListBoxItem();
        }
    }
}
