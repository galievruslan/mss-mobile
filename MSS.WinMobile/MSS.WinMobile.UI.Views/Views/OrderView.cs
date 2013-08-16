using System;
using MSS.WinMobile.Localization;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class OrderView : View, IOrderView {

        private OrderPresenter _presenter;
        private readonly IPresentersFactory _presentersFactory;
        private readonly RoutePointViewModel _routePointViewModel;
        private readonly OrderViewModel _orderViewModel;

        internal OrderView() {
            InitializeComponent();
        }

        private readonly ILocalizationManager _localizationManager;
        public OrderView(ILocalizationManager localizationManager) : this() {
            _localizationManager = localizationManager;

            _orderDateLabel.Text = _localizationManager.Localization.GetLocalizedValue(_orderDateLabel.Text);
            _shippingDateLabel.Text = _localizationManager.Localization.GetLocalizedValue(_shippingDateLabel.Text);
            _shippingDatePicker.CustomFormat = _localizationManager.Localization.GetLocalizedValue("dateformat");
            _customerLabel.Text = _localizationManager.Localization.GetLocalizedValue(_customerLabel.Text);
            _addressLabel.Text = _localizationManager.Localization.GetLocalizedValue(_addressLabel.Text);
            _priceLabel.Text = _localizationManager.Localization.GetLocalizedValue(_priceLabel.Text);
            _warehouseLabel.Text = _localizationManager.Localization.GetLocalizedValue(_warehouseLabel.Text);
            _amountLabel.Text = _localizationManager.Localization.GetLocalizedValue(_amountLabel.Text);
            _generalTab.Text = _localizationManager.Localization.GetLocalizedValue(_generalTab.Text);
            _detailsTab.Text = _localizationManager.Localization.GetLocalizedValue(_detailsTab.Text);
            _notesTab.Text = _localizationManager.Localization.GetLocalizedValue(_notesTab.Text);
            orderItemListBox.LocalizationManager = localizationManager;
        }

        public OrderView(IPresentersFactory presentersFactory,
                         ILocalizationManager localizationManager,
                         RoutePointViewModel routePointViewModel)
            : this(localizationManager) {
            _presentersFactory = presentersFactory;
            _routePointViewModel = routePointViewModel;
        }

        public OrderView(IPresentersFactory presentersFactory, 
                         ILocalizationManager localizationManager,
                         RoutePointViewModel routePointViewModel,
                         OrderViewModel orderViewModel)
            : this(localizationManager) {
            _presentersFactory = presentersFactory;
            _routePointViewModel = routePointViewModel;
            _orderViewModel = orderViewModel;
        }

        public OrderView(IPresentersFactory presentersFactory,
                         ILocalizationManager localizationManager,
                         OrderViewModel orderViewModel)
            : this(localizationManager)
        {
            _presentersFactory = presentersFactory;
            _orderViewModel = orderViewModel;
        }

        private OrderViewModel _viewModel;
        private void OrderViewLoad(object sender, EventArgs e) {
            if (_presenter == null) {
                if (_orderViewModel != null && _routePointViewModel != null)
                    _presenter = _presentersFactory.CreateOrderPresenter(this,
                                                                         _routePointViewModel,
                                                                         _orderViewModel);
                else {
                    if (_routePointViewModel != null)
                        _presenter = _presentersFactory.CreateOrderPresenter(this,
                                                                _routePointViewModel);
                    else
                        _presenter = _presentersFactory.CreateOrderPresenter(this, _orderViewModel);
                }

                _viewModel = _presenter.Initialize();

                _orderDateTextBox.Text = _viewModel.OrderDate.ToString(_localizationManager.Localization.GetLocalizedValue("dateformat"));
                _shippingDatePicker.Value = _viewModel.ShippingDate;
                _customerTextBox.Text = _viewModel.CustomerName;
                _shippingAddressTextBox.Text = _viewModel.ShippingAddressName;
                _priceListTextBox.Text = _viewModel.PriceListName;
                _warehouseTextBox.Text = _viewModel.WarehouseName;
                _amountValueLable.Text = _viewModel.Amount.ToString(_localizationManager.Localization.GetLocalizedValue("decimalformat"));
                _notesTextBox.Text = _viewModel.Note;

                orderItemListBox.ItemDataNeeded += ItemDataNeeded;
                orderItemListBox.ItemSelected += ItemSelected;
                orderItemListBox.SetListSize(_presenter.InitializeListSize());

                ViewContainer.RegisterLeftAction(new Save(_presenter));
                ViewContainer.RegisterRightAction(new Cancel(_presenter));
            }
        }

        private void ItemSelected(object sender, VirtualListBoxItem item) {
            _presenter.Select(item.Index);
        }

        private void ItemDataNeeded(object sender, VirtualListBoxItem item) {
            var orderItemListBoxItem = item as OrderItemListBoxItem;
            if (orderItemListBoxItem != null) {
                orderItemListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        private void AddClick(object sender, EventArgs e) {
            _presenter.PickUpProducts();
            orderItemListBox.SetListSize(_presenter.InitializeListSize());
            orderItemListBox.Refresh();
            _amountValueLable.Text = _viewModel.Amount.ToString(_localizationManager.Localization.GetLocalizedValue("decimalformat"));
            _amountValueLable.Refresh();
        }

        private void PriceListlookUp(object sender, EventArgs e) {
            _presenter.LookUpPriceList();
            _priceListTextBox.Text = _viewModel.PriceListName;
            _priceListTextBox.Refresh();
            orderItemListBox.SetListSize(_presenter.InitializeListSize());
            _amountValueLable.Text = _viewModel.Amount.ToString(_localizationManager.Localization.GetLocalizedValue("decimalformat"));
            _amountValueLable.Refresh();
        }

        private void WarehouseLookUp(object sender, EventArgs e) {
            _presenter.LookUpWarehouse();
            _warehouseTextBox.Text = _viewModel.WarehouseName;
            _warehouseTextBox.Refresh();
        }

        private void PriceListReset(object sender, EventArgs e) {
            _presenter.ResetPriceList();
            _priceListTextBox.Text = _viewModel.PriceListName;
            _priceListTextBox.Refresh();
            orderItemListBox.SetListSize(_presenter.InitializeListSize());
            _amountValueLable.Text = _viewModel.Amount.ToString(_localizationManager.Localization.GetLocalizedValue("decimalformat"));
            _amountValueLable.Refresh();
        }

        private void WarehouseReset(object sender, EventArgs e) {
            _presenter.ResetWarehouse();
            _warehouseTextBox.Text = _viewModel.WarehouseName;
            _warehouseTextBox.Refresh();
        }

        private void ShippingDatePickerValueChanged(object sender, EventArgs e) {
            _viewModel.ShippingDate = _shippingDatePicker.Value;
        }

        private void NotesTextBoxTextChanged(object sender, EventArgs e) {
            _viewModel.Note = _notesTextBox.Text;
        }

        private class Save : IViewAction {
            private readonly OrderPresenter _presenter;
            public Save(OrderPresenter presenter) {
                _presenter = presenter;
            }

            public string Caption {
                get { return "Save"; }
            }
            public void Do(object sender, EventArgs e) {
                _presenter.Save();
            }
        }

        private class Cancel : IViewAction {
            private readonly OrderPresenter _presenter;
            public Cancel(OrderPresenter presenter) {
                _presenter = presenter;
            }

            public string Caption {
                get { return "Cancel"; }
            }
            public void Do(object sender, EventArgs e) {
                _presenter.Cancel();
            }
        }

        private void _deleteButton_Click(object sender, EventArgs e) {
            _presenter.DeleteItem();
            orderItemListBox.SetListSize(_presenter.InitializeListSize());
            _amountValueLable.Text = _viewModel.Amount.ToString(_localizationManager.Localization.GetLocalizedValue("decimalformat"));
            _amountValueLable.Refresh();
        }
    }
}
