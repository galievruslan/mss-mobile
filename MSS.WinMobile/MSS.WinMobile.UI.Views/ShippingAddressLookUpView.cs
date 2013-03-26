using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class ShippingAddressLookUpView : Form, IShippingAddressLookUpView
    {
        private ShippingAddressLookUpPresenter _presenter;

        private readonly int _customerId;
        public ShippingAddressLookUpView(int customerId)
        {
            _customerId = customerId;
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
                shippingAddressListBox.ItemDataNeeded += ItemDataNeeded;
                shippingAddressListBox.ItemSelected += ItemSelected;
                _presenter = new ShippingAddressLookUpPresenter(this, _customerId);
                _presenter.InitializeView();
            }
        }

        void ItemSelected(object sender, VirtualListBoxItem item)
        {
            _presenter.SelectItem(item.Index);
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var shippingAddressListBoxItem = item as ShippingAddressListBoxItem;
            if (shippingAddressListBoxItem != null)
            {
                shippingAddressListBoxItem.SetAddress(_presenter.GetItemName(item.Index));
            }
        }

        private void CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkClick(object sender, EventArgs e)
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
            shippingAddressListBox.SetListSize(count);
        }

        public int GetSelectedId()
        {
            return _presenter.GetSelectedItemId();
        }
    }
}