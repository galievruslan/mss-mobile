using System;
using System.Windows.Forms;
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

        private readonly int _shippingAddressId;

        public OrderView(int shippinAddressId)
        {
            InitializeComponent();
            _shippingAddressId = shippinAddressId;
        }

        public void DisplayErrors(string error)
        {
            throw new NotImplementedException();
        }

        private void OrderView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _presenter = new OrderPresenter(this, _shippingAddressId);
                _presenter.InitializeView();
            }
        }

        private void PasswordTextBoxTextChanged(object sender, EventArgs e)
        {

        }

        private void AccountTextBoxTextChanged(object sender, EventArgs e)
        {

        }
    }
}