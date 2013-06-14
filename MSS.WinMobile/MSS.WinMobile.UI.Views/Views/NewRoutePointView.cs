using System;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class NewRoutePointView : View, INewRoutePointView {
        public NewRoutePointView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private readonly ILocalizationManager _localizationManager;
        private NewRoutePointPresenter _presenter;
        private readonly RouteViewModel _routeViewModel;

        private NewRoutePointViewModel _viewModel;
        

        public NewRoutePointView(IPresentersFactory presentersFactory, ILocalizationManager localizationManager,
                                 RouteViewModel routeViewModel)
            : this() {
            _presentersFactory = presentersFactory;
            _localizationManager = localizationManager;
            _routeViewModel = routeViewModel;

            _customerLabel.Text = _localizationManager.Localization.GetLocalizedValue(_customerLabel.Text);
            _shippingAddressLabel.Text =
                _localizationManager.Localization.GetLocalizedValue(_shippingAddressLabel.Text);
        }

        private void NewRoutePointViewLoad(object sender, EventArgs e) {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateNewRoutePointPresenter(this, _routeViewModel);
                _viewModel = _presenter.Initialize();

                ViewContainer.RegisterLeftAction(new Save(_presenter));
                ViewContainer.RegisterRightAction(new Cancel(_presenter));

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

        private class Save : IViewAction {
            private readonly NewRoutePointPresenter _presenter;
            public Save(NewRoutePointPresenter presenter) {
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
            private readonly NewRoutePointPresenter _presenter;
            public Cancel(NewRoutePointPresenter presenter) {
                _presenter = presenter;
            }

            public string Caption {
                get { return "Cancel"; }
            }
            public void Do(object sender, EventArgs e) {
                _presenter.Cancel();
            }
        }
    }
}
