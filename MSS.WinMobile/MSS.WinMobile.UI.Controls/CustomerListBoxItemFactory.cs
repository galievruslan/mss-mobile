using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox;

namespace MSS.WinMobile.UI.Controls
{
    public class CustomerListBoxItemFactory : VirtualListBoxItemFactory<Customer>
    {
        public override IListBoxItem<Customer> CreateNewListBoxItem()
        {
            return new CustomerListBoxItem();
        }
    }
}
