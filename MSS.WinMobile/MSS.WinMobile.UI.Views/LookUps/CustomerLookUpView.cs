using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Views.LookUps
{
    public partial class CustomerLookUpView : LookUpView, ICustomerLookUpView
    {
        public CustomerLookUpView()
        {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private CustomerLookUpPresenter _presenter;

        public CustomerLookUpView(IPresentersFactory presentersFactory) {
            InitializeComponent();
            _presentersFactory = presentersFactory;
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateCustomerLookUpPresenter(this);
                customerListBox.ItemDataNeeded += ItemDataNeeded;
                customerListBox.ItemSelected += ItemSelected;
                customerListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        void ItemSelected(object sender, VirtualListBoxItem item) {
            _presenter.Select(item.Index);
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var customerListBoxItem = item as CustomerListBoxItem;
            if (customerListBoxItem != null)
            {
                customerListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        public CustomerViewModel SelectedCustomer {
            get { return _presenter.SelectedModel; }
        }

        private void OkButtonClick(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}