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
        private readonly int _routeId;

        private NewRoutePointViewModel _viewModel;
        public NewRoutePointView(IPresentersFactory presentersFactory, int routeId) {
            InitializeComponent();

            _presentersFactory = presentersFactory;
            _routeId = routeId;
        }

        private void NewRoutePointView_Load(object sender, EventArgs e) {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateNewRoutePointPresenter(this, _routeId);
                _viewModel = _presenter.Initialize();
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

        private void _customerLookUpButton_Click(object sender, EventArgs e) {
            _presenter.LookUpCustomer();
            Refresh();
        }

        private void _customerResetButton_Click(object sender, EventArgs e) {
            _presenter.ResetCustomer();
            Refresh();
        }

        private void _shippingAddressLookUpButton_Click(object sender, EventArgs e) {
            _presenter.LookUpShippingAddress();
            Refresh();
        }

        private void _shippingAddressResetButton_Click(object sender, EventArgs e) {
            _presenter.ResetShippingAddress();
            Refresh();
        }

        private void okButton_Click(object sender, EventArgs e) {
            if (_presenter.Save())
                DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            _presenter.Cancel();
        }
    }
}