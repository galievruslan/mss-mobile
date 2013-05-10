using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class ShippingAddressLookUpView : Form, IShippingAddressLookUpView
    {
        public ShippingAddressLookUpView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private ShippingAddressLookUpPresenter _presenter;

        private readonly int _customerId;
        public ShippingAddressLookUpView(IPresentersFactory presentersFactory, int customerId) {
            InitializeComponent();

            _presentersFactory = presentersFactory;
            _customerId = customerId;
        }

        private void CustomerLookUpView_Load(object sender, EventArgs e)
        {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateShippingAddressLookUpPresenter(this,
                                                                                     _customerId);
                //shippingAddressListBox.ItemDataNeeded += ItemDataNeeded;
                //shippingAddressListBox.ItemSelected += ItemSelected;
                //_presenter = new ShippingAddressLookUpPresenter(this, _customerId);
                //_presenter.InitializeView();
            }
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            //var shippingAddressListBoxItem = item as ShippingAddressListBoxItem;
            //if (shippingAddressListBoxItem != null)
            //{
            //    shippingAddressListBoxItem.SetData(_presenter.GetItemData(item.Index));
            //}
        }

        #region IView

        public void ShowView()
        {
            Show();
        }

        public DialogViewResult ShowDialogView()
        {
            DialogResult dialogResult = ShowDialog();
            if (dialogResult == DialogResult.OK)
                return DialogViewResult.Ok;

            return DialogViewResult.Cancel;
        }

        public void CloseView()
        {
            Close();
        }

        public void DisplayErrors(string error)
        {
            throw new NotImplementedException();
        }

        #endregion

        public ShippingAddressViewModel SelectedShippingAddress {
            get { return _presenter.SelectedModel; }
        }

        private void okButton_Click_1(object sender, EventArgs e) {
            if (_presenter.LookUp()) {
                DialogResult = DialogResult.OK;
            }
        }

        private void cancelButton_Click_1(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            _presenter.Cancel();
        }
    }
}