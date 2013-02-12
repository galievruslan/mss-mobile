using System.Windows.Forms;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class CustomersView : UserControl, ICustomersView
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        public CustomersView(ILayout layout)
        {
            InitializeComponent();
            _customersListBox.ItemFactory = new CustomerListBoxItemFactory();
            _customersListBox.ItemDataNeeded += _customersListBox_ItemDataNeeded;
            _customersListBox.ItemCount = 50;
        }

        void _customersListBox_ItemDataNeeded(object sender, Controls.ListBox.IListBoxItem<Customer> item)
        {
            item.Data = new Customer
                {
                    Id = item.Index,
                    Name = string.Format("Customer #{0}", item.Index)
                };
        }
    }
}
