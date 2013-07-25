using System;
using System.Collections.Generic;
using MSS.WinMobile.Localization;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Views.LookUps {
    public partial class PickUpProductView : LookUpView, IPickUpProductView {
        private PickUpProductPresenter _presenter;
        private readonly IPresentersFactory _presentersFactory;
        private readonly PriceListViewModel _priceListViewModel;
        private readonly IEnumerable<OrderItemViewModel> _orderItemViewModels;

        internal PickUpProductView() {
            InitializeComponent();
        }

        public PickUpProductView(IPresentersFactory presentersFactory,
                                 ILocalizationManager localizationManager,
                                 PriceListViewModel priceListViewModel,
                                 IEnumerable<OrderItemViewModel> orderItemViewModels)
            : base(localizationManager) {

            InitializeComponent();
            _presentersFactory = presentersFactory;
            _priceListViewModel = priceListViewModel;
            _orderItemViewModels = orderItemViewModels;

            Text = localizationManager.Localization.GetLocalizedValue(Text);
            _productPriceListBox.LocalizationManager = LocalizationManager;
            searchPanel.LocalizationManager = LocalizationManager;
            _productPickUpExtraPanel.LocalizationManager = LocalizationManager;
        }

        private void ViewLoad(object sender, EventArgs e) {
            if (_presenter == null) {
                _productPriceListBox.ItemDataNeeded += ItemDataNeeded;
                _productPriceListBox.ItemSelected += ItemSelected;
                _presenter = _presentersFactory.CreatePickUpProductPresenter(this,
                                                                             _priceListViewModel,
                                                                             _orderItemViewModels);
                _productPriceListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        private VirtualListBoxItem _selectedItem;
        private void ItemSelected(object sender, VirtualListBoxItem item) {
            _selectedItem = item;
            _presenter.Select(item.Index);
            _productPickUpExtraPanel.SetUnitsOfMeasures(_presenter.GetProductsUntisOfMeasure());
            _productPickUpExtraPanel.SetSelectedUnitOfMeasure(_presenter.SelectedModel.UnitOfMeasureId);
        }

        private void ItemDataNeeded(object sender, VirtualListBoxItem item) {
            var productPriceListBoxItem = item as ProductPriceListBoxItem;
            if (productPriceListBoxItem != null) {
                productPriceListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        public void SetCategoryFilter(string filter) {
            _filterPanel.SetFilterValue(filter);
        }

        public void SetAmount(decimal value) {
            _productPickUpExtraPanel.SetAmount(value);
            _productPickUpExtraPanel.Refresh();
        }

        public IList<PickUpProductViewModel> PickedUpProducts {
            get { return _presenter.PickedUpProducts; }
        }

        private void FilterClick(object sender) {
            _presenter.ChangeCategoryFilter();
            _selectedItem = null;
            _productPriceListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void ClearFilterClick(object sender) {
            _presenter.ClearCategoryFilter();
            _selectedItem = null;
            _productPriceListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void ClearSearchClick(object sender) {
            _presenter.ClearSearch();
            _selectedItem = null;
            _productPriceListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void SearchClick(object sender, string criteria) {
            _presenter.Search(criteria);
            _selectedItem = null;
            _productPriceListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void InformationButtonClick(object sender, EventArgs e) {
            _presenter.ShowDetails();
        }

        private void quantityPanel_DigitAdd(int value) {
            _presenter.AddDigit(value);
            if (_selectedItem != null)
                _selectedItem.RefreshData();
        }

        private void quantityPanel_DigitRemove() {
            _presenter.RemoveDigit();
            if (_selectedItem != null)
                _selectedItem.RefreshData();
        }

        private void productPickUpExtraPanel1_UnitOfMeasureChanged(UnitOfMeasureViewModel unitOfMeasureViewModel) {
            _presenter.ChangeUnitOfMeasure(unitOfMeasureViewModel);
        }
    }
}