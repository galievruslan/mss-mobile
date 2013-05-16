using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Views.LookUps
{
    public partial class PickUpProductView : Form, IPickUpProductView
    {
        private PickUpProductPresenter _presenter;
        private readonly IPresentersFactory _presentersFactory;
        private readonly PriceListViewModel _priceListViewModel;
        private readonly IEnumerable<OrderItemViewModel> _orderItemViewModels; 

        public PickUpProductView()
        {
            InitializeComponent();
        }

        public PickUpProductView(IPresentersFactory presentersFactory, PriceListViewModel priceListViewModel, IEnumerable<OrderItemViewModel> orderItemViewModels)
            :this() {
            _presentersFactory = presentersFactory;
            _priceListViewModel = priceListViewModel;
            _orderItemViewModels = orderItemViewModels;
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _productPriceListBox.ItemDataNeeded += ItemDataNeeded;
                _productPriceListBox.ItemSelected += ItemSelected;
                _presenter = _presentersFactory.CreatePickUpProductPresenter(this, _priceListViewModel, _orderItemViewModels);
                _productPriceListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        private VirtualListBoxItem _selectedItem;
        void ItemSelected(object sender, VirtualListBoxItem item) {

            _selectedItem = item;
            _presenter.Select(item.Index);
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var productPriceListBoxItem = item as ProductPriceListBoxItem;
            if (productPriceListBoxItem != null)
            {
                productPriceListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        private void DigitButtonClick(object sender, EventArgs e)
        {
            var digitButton = sender as Button;
            if (digitButton != null)
            {
                _presenter.AddDigit(Int32.Parse(digitButton.Text));
                if (_selectedItem != null)
                    _selectedItem.RefreshData();
            }
        }

        private void DeleteDigitButtonClick(object sender, EventArgs e)
        {
            _presenter.RemoveDigit();
            if (_selectedItem != null)
                _selectedItem.RefreshData();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public IList<PickUpProductViewModel> PickedUpProducts {
            get { return _presenter.PickedUpProducts; }
        }

        public void ShowInformation(string message) {
            throw new NotImplementedException();
        }

        public void ShowError(string message) {
            throw new NotImplementedException();
        }
    }
}