using System;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class NewRoutePointView : View, INewRoutePointView {
        public NewRoutePointView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private NewRoutePointPresenter _presenter;
        private readonly RouteViewModel _routeViewModel;

        private NewRoutePointViewModel _viewModel;
        public NewRoutePointView(IPresentersFactory presentersFactory, RouteViewModel routeViewModel) {
            InitializeComponent();

            _presentersFactory = presentersFactory;
            _routeViewModel = routeViewModel;
        }

        private void NewRoutePointViewLoad(object sender, EventArgs e) {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateNewRoutePointPresenter(this, _routeViewModel);
                _viewModel = _presenter.Initialize();

                _customerTextBox.Text = _viewModel.CustomerName;
                _shippingAddressTextBox.Text = _viewModel.ShippingAddressName;
            }
        }

        private void CustomerLookUpButtonClick(object sender, EventArgs e) {
            _presenter.LookUpCustomer();
            _customerTextBox.Text = _viewModel.CustomerName;
            _shippingAddressTextBox.Text = _viewModel.ShippingAddressName;
            _customerTextBox.Refresh();
            _shippingAddressTextBox.Refresh();
        }

        private void CustomerResetButtonClick(object sender, EventArgs e) {
            _presenter.ResetCustomer();
            _customerTextBox.Text = _viewModel.CustomerName;
            _shippingAddressTextBox.Text = _viewModel.ShippingAddressName;
            _customerTextBox.Refresh();
            _shippingAddressTextBox.Refresh();
        }

        private void OkButtonClick(object sender, EventArgs e) {
            _presenter.Save();
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            _presenter.Cancel();
        }

        private void ShippingAddressLookUpButtonClick(object sender, EventArgs e) {
            _presenter.LookUpShippingAddress();
            _shippingAddressTextBox.Text = _viewModel.ShippingAddressName;
            _shippingAddressTextBox.Refresh();
        }

        private void ShippingAddressResetButtonClick(object sender, EventArgs e) {
            _presenter.ResetShippingAddress();
            _shippingAddressTextBox.Text = _viewModel.ShippingAddressName;
            _shippingAddressTextBox.Refresh();
        }
    }
}
