using System;
using System.Globalization;
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

        public OrderView() {
            InitializeComponent();
        }

        public OrderView(IPresentersFactory presentersFactory,
                         RoutePointViewModel routePointViewModel)
            : this() {
            _presentersFactory = presentersFactory;
            _routePointViewModel = routePointViewModel;
        }

        public OrderView(IPresentersFactory presentersFactory, 
                         RoutePointViewModel routePointViewModel,
                         OrderViewModel orderViewModel)
            : this() {
            _presentersFactory = presentersFactory;
            _routePointViewModel = routePointViewModel;
            _orderViewModel = orderViewModel;
        }

        public OrderView(IPresentersFactory presentersFactory,
                         OrderViewModel orderViewModel)
            : this()
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

                _orderDateTextBox.Text = _viewModel.OrderDate.ToString("dd.MM.yyyy");
                _shippingDatePicker.Value = _viewModel.ShippingDate;
                _customerTextBox.Text = _viewModel.CustomerName;
                _shippingAddressTextBox.Text = _viewModel.ShippingAddressName;
                _priceListTextBox.Text = _viewModel.PriceListName;
                _warehouseTextBox.Text = _viewModel.WarehouseAddress;
                _amountValueLable.Text = _viewModel.Amount.ToString(CultureInfo.InvariantCulture);
                _notesTextBox.Text = _viewModel.Note;

                orderItemListBox.ItemDataNeeded += ItemDataNeeded;
                orderItemListBox.ItemSelected += ItemSelected;
                orderItemListBox.SetListSize(_presenter.InitializeListSize());
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
            _amountValueLable.Text = _viewModel.Amount.ToString(CultureInfo.InvariantCulture);
            _amountValueLable.Refresh();
        }

        private void PriceListlookUp(object sender, EventArgs e) {
            _presenter.LookUpPriceList();
            _priceListTextBox.Text = _viewModel.PriceListName;
            _priceListTextBox.Refresh();
        }

        private void WarehouseLookUp(object sender, EventArgs e) {
            _presenter.LookUpWarehouse();
            _warehouseTextBox.Text = _viewModel.WarehouseAddress;
            _warehouseTextBox.Refresh();
        }

        private void PriceListReset(object sender, EventArgs e) {
            _presenter.ResetPriceList();
            _priceListTextBox.Text = _viewModel.PriceListName;
            _priceListTextBox.Refresh();
        }

        private void WarehouseReset(object sender, EventArgs e) {
            _presenter.ResetWarehouse();
            _warehouseTextBox.Text = _viewModel.WarehouseAddress;
            _warehouseTextBox.Refresh();
        }

        private void OkButtonClick(object sender, EventArgs e) {
            _presenter.Save();
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            _presenter.Cancel();
        }

        private void ShippingDatePickerValueChanged(object sender, EventArgs e) {
            _viewModel.ShippingDate = _shippingDatePicker.Value;
        }

        private void NotesTextBoxTextChanged(object sender, EventArgs e) {
            _viewModel.Note = _notesTextBox.Text;
        }
    }
}
