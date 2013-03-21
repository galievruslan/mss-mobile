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

        public OrderView()
        {
            InitializeComponent();
        }

        private Order _order;
        public OrderView(int shippinAddressId)
        {
            InitializeComponent();
        }

        public void DisplayErrors(string error)
        {
            throw new NotImplementedException();
        }

        private void OrderView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                //_presenter = new OrderPresenter(this, _shippingAddressId);
                //_presenter.InitializeView();
            }
        }

        private void OkButtonClick(object sender, EventArgs e)
        {

        }

        private void CancelButtonClick(object sender, EventArgs e)
        {

        }

        public void SetNumber(int number)
        {
            _noTextBox.Text = number.ToString(CultureInfo.InvariantCulture);
        }

        public void SetDate(DateTime date)
        {
            _dateTextBox.Text = date.ToShortDateString();
        }

        public void SetCustomer(string customer)
        {
            _customerComboBox.Text = customer;
        }

        public void SetShipmentAddress(string address)
        {
            _addressComboBox.Text = address;
        }

        public void SetPrice(string price)
        {
            _priceComboBox.Text = price;
        }

        public void SetWarehouse(string warehouse)
        {
            _warehouseComboBox.Text = warehouse;
        }

        public void SetNote(string note)
        {
            _notesTextBox.Text = note;
        }
    }
}