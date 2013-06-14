using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.Resources;
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
            var productsUoM = _presenter.GetProductsUntisOfMeasure();
            _uomComboBox.SelectedValueChanged -= _uomComboBox_SelectedValueChanged;
            _uomComboBox.DataSource = productsUoM;
            foreach (var unitOfMeasureViewModel in productsUoM) {
                if (unitOfMeasureViewModel.Id == _presenter.SelectedModel.UnitOfMeasureId) {
                    _uomComboBox.SelectedItem = unitOfMeasureViewModel;
                    break;
                }
            }
            _uomComboBox.SelectedValueChanged += _uomComboBox_SelectedValueChanged;
        }

        private void ItemDataNeeded(object sender, VirtualListBoxItem item) {
            var productPriceListBoxItem = item as ProductPriceListBoxItem;
            if (productPriceListBoxItem != null) {
                productPriceListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        private void DigitButtonClick(object sender, EventArgs e) {
            var digitButton = sender as Button;
            if (digitButton != null) {
                _presenter.AddDigit(Int32.Parse(digitButton.Text));
                if (_selectedItem != null)
                    _selectedItem.RefreshData();
            }
        }

        private void DeleteDigitButtonClick(object sender, EventArgs e) {
            _presenter.RemoveDigit();
            if (_selectedItem != null)
                _selectedItem.RefreshData();
        }

        public void SetCategoryFilter(string filter) {
            _filterPanel.SetFilterValue(filter);
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

        private void _uomComboBox_SelectedValueChanged(object sender, EventArgs e) {
            _presenter.ChangeUnitOfMeasure((UnitOfMeasureViewModel)_uomComboBox.SelectedItem);
        }
    }
}