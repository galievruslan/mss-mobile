using System;
using System.Windows.Forms;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class ShippingAddressLookUpView : Form, IShippingAddressLookUpView
    {
        private ShippingAddressLookUpPresenter _presenter;

        private readonly Customer _customer;
        public ShippingAddressLookUpView(Customer customer)
        {
            _customer = customer;
            InitializeComponent();
        }

        public ShippingAddressLookUpView()
        {
            InitializeComponent();
        }

        private void CustomerLookUpView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                shippingAddressListBox.ItemDataNeeded += shippingAddressListBox_ItemDataNeeded;
                shippingAddressListBox.ItemSelected += shippingAddressListBox_ItemSelected;
                _presenter = new ShippingAddressLookUpPresenter(this, _customer);
                _presenter.InitializeView();
            }
        }

        private ShippingAddress _selectedShippingAddress;
        public ShippingAddress GetSelectedShippingAddress()
        {
            return _selectedShippingAddress;
        }

        void shippingAddressListBox_ItemSelected(object sender, Controls.ListBox.ListBoxItems.VirtualListBoxItem<ShippingAddress> item)
        {
            _selectedShippingAddress = item.Data;
        }

        void shippingAddressListBox_ItemDataNeeded(object sender, Controls.ListBox.ListBoxItems.VirtualListBoxItem<ShippingAddress> item)
        {
            item.Data = _presenter.GetShippingAddress(item.Index);
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

        public void SetShippingAddressCount(int count)
        {
            shippingAddressListBox.SetListSize(count);
        }
    }
}