using System;
using System.Windows.Forms;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class CustomerLookUpView : Form, ICustomerLookUpView
    {
        private CustomerLookUpPresenter _presenter;

        public CustomerLookUpView()
        {
            InitializeComponent();
        }

        private void CustomerLookUpView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                customerListBox.ItemDataNeeded += customerListBox_ItemDataNeeded;
                customerListBox.ItemSelected += customerListBox_ItemSelected;
                _presenter = new CustomerLookUpPresenter(this);
                _presenter.InitializeView();
            }
        }

        private Customer _selectedCustomer;
        public Customer GetSelectedCustomer()
        {
            return _selectedCustomer;
        }

        void customerListBox_ItemSelected(object sender, Controls.ListBox.ListBoxItems.VirtualListBoxItem<Customer> item)
        {
            _selectedCustomer = item.Data;
        }

        void customerListBox_ItemDataNeeded(object sender, Controls.ListBox.ListBoxItems.VirtualListBoxItem<Customer> item)
        {
            item.Data = _presenter.GetCustomer(item.Index);
        }

        public void SetCustomerCount(int count)
        {
            customerListBox.SetListSize(count);
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}