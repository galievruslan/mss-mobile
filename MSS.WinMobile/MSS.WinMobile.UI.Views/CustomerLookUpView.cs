using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

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

        void customerListBox_ItemSelected(object sender, VirtualListBoxItem item)
        {
            _presenter.SelectItem(item.Index);
        }

        void customerListBox_ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var customerListBoxItem = item as CustomerListBoxItem;
            if (customerListBoxItem != null)
            {
                customerListBoxItem.SetName(_presenter.GetItemName(item.Index));
            }
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

        public void DisplayErrors(string error)
        {
            throw new NotImplementedException();
        }

        public void SetItemCount(int count)
        {
            customerListBox.SetListSize(count);
        }

        public int GetSelectedId()
        {
            return _presenter.GetSelectedItemId();
        }
    }
}