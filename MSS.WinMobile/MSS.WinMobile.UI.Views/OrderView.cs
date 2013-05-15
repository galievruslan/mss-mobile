using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views {
    public partial class OrderView : Form//, IOrderView 
    {
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

        public OrderView(IPresentersFactory presentersFactory, OrderViewModel orderViewModel)
            : this() {
            _presentersFactory = presentersFactory;
            _orderViewModel = orderViewModel;
        }

        private OrderViewModel _viewModel;

        private void ViewLoad(object sender, EventArgs e) {
            if (_presenter == null) {
                //_presenter = _routePointViewModel != null
                //                 ? _presentersFactory.CreateOrderPresenter(this,
                //                                                           _routePointViewModel)
                //                 : _presentersFactory.CreateOrderPresenter(this, _orderViewModel);

                _viewModel = _presenter.Initialize();

                _orderDatePicker.Value = _viewModel.OrderDate;
                _shippingDatePicker.Value = _viewModel.ShippingDate;
                _customerTextBox.Text = _viewModel.CustomerName;
                _shippingAddressTextBox.Text = _viewModel.ShippingAddressName;
                _priceListTextBox.Text = _viewModel.PriceListName;
                _warehouseTextBox.Text = _viewModel.WarehouseAddress;
                _notesTextBox.Text = _viewModel.Note;

                _orderItemListBox.ItemDataNeeded += ItemDataNeeded;
                _orderItemListBox.ItemSelected += ItemSelected;
                _orderItemListBox.SetListSize(_presenter.InitializeListSize());
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
            if (_presenter.PickUpProducts()) {
                _orderItemListBox.SetListSize(_presenter.InitializeListSize());
            }
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
            if (_presenter.Save())
                DialogResult = DialogResult.OK;

        }

        private void CancelButtonClick(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
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