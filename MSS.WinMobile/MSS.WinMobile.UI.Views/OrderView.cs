using System;
using System.Globalization;
using System.Windows.Forms;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class OrderView : Form, IOrderView
    {
        private OrderPresenter _presenter;
        private readonly RoutePoint _routePoint;
        private Order _order;

        public OrderView()
        {
            InitializeComponent();
        }

        public OrderView(RoutePoint routePoint)
            :this()
        {
            _routePoint = routePoint;
        }

        public void DisplayErrors(string error)
        {
            notification.Critical = true;
            notification.Text = error;
            notification.Visible = true;
        }

        public void SetOrder(Order order)
        {
            _order = order;
            _noTextBox.Text = _order.Id.ToString(CultureInfo.InvariantCulture);
            _dateTextBox.Text = _order.Date.ToString(CultureInfo.InvariantCulture);
            if (_order.Customer != null)
                _customerLookUpBox.Label = _order.Customer.Name;
            if (_order.ShippingAddress != null)
                _shippingAddressLookUpBox.Label = _order.ShippingAddress.Address;
            if (_order.PriceList != null)
                _priceLookUpBox.Label = _order.PriceList.Name;
            if (_order.Warehouse != null)
                _warehouseLookUpBox.Label = _order.Warehouse.Address;
        }

        private void OrderView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _presenter = new OrderPresenter(this, _routePoint);
                _presenter.InitializeView();
            }
        }

        private void _customerLookUpBox_LookUp(Controls.LookUpBox sender)
        {
            using (var customerLookUpView = new CustomerLookUpView())
            {
                if (DialogResult.OK == customerLookUpView.ShowDialog())
                {
                    Customer customer = customerLookUpView.GetSelectedCustomer();
                    _order.SetCustomer(customer);

                    _customerLookUpBox.Label = customer.Name;
                    _shippingAddressLookUpBox.Label = string.Empty;
                }
            }
        }

        private void _addressLookUpBox_LookUp(Controls.LookUpBox sender)
        {
            if (_order.Customer != null)
            {
                using (
                    var shippingAddressLookUpView =
                        new ShippingAddressLookUpView(_order.Customer))
                {
                    if (DialogResult.OK == shippingAddressLookUpView.ShowDialog())
                    {
                        ShippingAddress shippingAddress = shippingAddressLookUpView.GetSelectedShippingAddress();
                        _order.SetShippingAddress(shippingAddress);
                        _shippingAddressLookUpBox.Label = shippingAddress.Address;
                    }
                }
            }
            else
            {
                notification.Text = "In first you should select a customer";
                notification.Visible = true;
            }
        }

        private void _priceLookUpBox_LookUp(Controls.LookUpBox sender)
        {

        }

        private void _warehouseLookUpBox_LookUp(Controls.LookUpBox sender)
        {

        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            if (_presenter.Save())
            {
                Close();
                Dispose();
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            if (_presenter.Cancel())
            {
                Close();
                Dispose();
            }
        }
    }
}