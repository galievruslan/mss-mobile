using System;
using MSS.WinMobile.Resources;
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
        public CustomerLookUpView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private CustomerLookUpPresenter _presenter;

        public CustomerLookUpView(IPresentersFactory presentersFactory, ILocalizator localizator) : base(localizator) {
            _presentersFactory = presentersFactory;

            customerListBox.Localizator = Localizator;
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

        private void CustomerListBoxItemInformationNeeded(object sender, VirtualListBoxItem item) {
            
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

        private void DoSearchClick(object sender, string criteria) {
            _presenter.Search(criteria);
            customerListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void ClearSearchClick(object sender) {
            _presenter.ClearSearch();
            customerListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void InformationButtonClick(object sender, EventArgs e) {
            _presenter.ShowDetails();
        }
    }
}