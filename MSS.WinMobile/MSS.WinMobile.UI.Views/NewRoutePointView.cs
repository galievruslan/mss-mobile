using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views {
    public partial class NewRoutePointView : Form, INewRoutePointView {
        public NewRoutePointView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private NewRoutePointPresenter _presenter;
        private readonly RouteViewModel _routeViewModel;

        private NewRoutePointViewModel _viewModel;
        public NewRoutePointView(IPresentersFactory presentersFactory, RouteViewModel routeViewModel)
        {
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

        

        #region IView

        public void ShowView() {
            Show();
        }

        public DialogViewResult ShowDialogView() {
            DialogResult dialogResult = ShowDialog();
            if (dialogResult == DialogResult.OK)
                return DialogViewResult.Ok;

            return DialogViewResult.Cancel;
        }

        public void CloseView() {
            Close();
            Dispose();
        }

        public void DisplayErrors(string error) {
            _notification.Critical = true;
            _notification.Text = error;
            _notification.Visible = true;
        }

        #endregion

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

        private void OkButtonClick(object sender, EventArgs e) {
            if (_presenter.Save())
                DialogResult = DialogResult.OK;
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            _presenter.Cancel();
        }
    }
}