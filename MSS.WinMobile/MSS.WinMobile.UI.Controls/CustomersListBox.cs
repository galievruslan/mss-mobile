using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox;

namespace MSS.WinMobile.UI.Controls
{
    public partial class CustomersListBox : VirtualListBox<Customer>
    {
        public CustomersListBox()
        {
            InitializeComponent();
        }

        protected override IListBoxItem<Customer> GetNewListItem()
        {
            return new CustomersListBoxItem();
        }
    }
}
