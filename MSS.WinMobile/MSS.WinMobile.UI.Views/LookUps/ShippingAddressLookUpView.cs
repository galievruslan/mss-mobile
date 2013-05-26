using System;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Views.LookUps
{
    public partial class ShippingAddressLookUpView : LookUpView, IShippingAddressLookUpView
    {
        public ShippingAddressLookUpView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private ShippingAddressLookUpPresenter _presenter;

        private readonly CustomerViewModel _customerViewModel;
        public ShippingAddressLookUpView(IPresentersFactory presentersFactory, CustomerViewModel customerViewModel) {
            InitializeComponent();

            _presentersFactory = presentersFactory;
            _customerViewModel = customerViewModel;
        }

        private void ShippingAddressLookUpViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateShippingAddressLookUpPresenter(this,
                                                                                     _customerViewModel);
                shippingAddressListBox.ItemDataNeeded += ItemDataNeeded;
                shippingAddressListBox.ItemSelected += ItemSelected;
                shippingAddressListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        void ItemSelected(object sender, VirtualListBoxItem item)
        {
            _presenter.Select(item.Index);
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var shippingAddressListBoxItem = item as ShippingAddressListBoxItem;
            if (shippingAddressListBoxItem != null)
            {
                shippingAddressListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        public ShippingAddressViewModel SelectedShippingAddress {
            get { return _presenter.SelectedModel; }
        }

        private void DoSearchClick(object sender, string criteria) {
            _presenter.Search(criteria);
            shippingAddressListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void ClearSearchClick(object sender) {
            _presenter.ClearSearch();
            shippingAddressListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void InformationButtonClick(object sender, EventArgs e) {
            _presenter.ShowDetails();
        }
    }
}