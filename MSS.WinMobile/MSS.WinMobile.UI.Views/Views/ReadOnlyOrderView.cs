using System;
using System.Globalization;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class ReadOnlyOrderView : View, IOrderView {

        private OrderPresenter _presenter;
        private readonly IPresentersFactory _presentersFactory;
        private readonly RoutePointViewModel _routePointViewModel;
        private readonly OrderViewModel _orderViewModel;

        public ReadOnlyOrderView() {
            InitializeComponent();
        }

        public ReadOnlyOrderView(IPresentersFactory presentersFactory, 
                         RoutePointViewModel routePointViewModel,
                         OrderViewModel orderViewModel)
            : this() {
            _presentersFactory = presentersFactory;
            _routePointViewModel = routePointViewModel;
            _orderViewModel = orderViewModel;
        }

        public ReadOnlyOrderView(IPresentersFactory presentersFactory,
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
                else
                {
                    if (_routePointViewModel != null)
                        _presenter = _presentersFactory.CreateOrderPresenter(this,
                                                                _routePointViewModel);
                    else
                        _presenter = _presentersFactory.CreateOrderPresenter(this, _orderViewModel);
                }

                _viewModel = _presenter.Initialize();

                _orderDataTextBox.Text = _viewModel.OrderDate.ToString("dd.MM.yyyy");
                _shippingDateTextBox.Text = _viewModel.ShippingDate.ToString("dd.MM.yyyy");
                _customerTextBox.Text = _viewModel.CustomerName;
                _shippingAddressTextBox.Text = _viewModel.ShippingAddressName;
                _priceListTextBox.Text = _viewModel.PriceListName;
                _warehouseTextBox.Text = _viewModel.WarehouseAddress;
                _amountValueLable.Text = _viewModel.Amount.ToString(CultureInfo.InvariantCulture);
                _notesTextBox.Text = _viewModel.Note;

                orderItemListBox.ItemDataNeeded += ItemDataNeeded;
                orderItemListBox.SetListSize(_presenter.InitializeListSize());

                ViewContainer.RegisterLeftAction(new StubAction());
                ViewContainer.RegisterLeftAction(new Back(_presenter));
            }
        }

        private void ItemDataNeeded(object sender, VirtualListBoxItem item) {
            var orderItemListBoxItem = item as OrderItemListBoxItem;
            if (orderItemListBoxItem != null) {
                orderItemListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        private class Back : IViewAction {
            private readonly OrderPresenter _presenter;
            public Back(OrderPresenter presenter) {
                _presenter = presenter;
            }

            public string Caption {
                get { return "Back"; }
            }
            public void Do(object sender, EventArgs e) {
                _presenter.Cancel();
            }
        }
    }
}
