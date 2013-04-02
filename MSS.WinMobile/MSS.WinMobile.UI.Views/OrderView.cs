using System;
using System.Globalization;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class OrderView : Form, IOrderView
    {
        private OrderPresenter _presenter;
        private readonly int _routePointId;

        public OrderView()
        {
            InitializeComponent();
        }

        public OrderView(int routePointId)
            :this()
        {
            _routePointId = routePointId;
        }

        private void OrderView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _presenter = new OrderPresenter(this, _routePointId);
                _presenter.InitializeView();
            }
        }

        private void PriceListLookUp(Controls.LookUpBox sender)
        {
            using (var priceListLookUpView = new PriceListLookUpView())
            {
                if (DialogResult.OK == priceListLookUpView.ShowDialog())
                {
                    int priceListId = priceListLookUpView.GetSelectedId();
                    _presenter.SetPriceList(priceListId);
                }
            }
        }

        private void WarehouseLookUp(Controls.LookUpBox sender)
        {
            using (var warehouseLookUpView = new WarehouseLookUpView())
            {
                if (DialogResult.OK == warehouseLookUpView.ShowDialog())
                {
                    int warehouseListId = warehouseLookUpView.GetSelectedId();
                    _presenter.SetWarehouse(warehouseListId);
                }
            }
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

        public void SetNumber(string number)
        {
            _noTextBox.Text = number;
        }

        public void SetDate(DateTime date)
        {
            _dateTextBox.Text = date.ToString(CultureInfo.InvariantCulture);
        }

        public void SetCustomer(string name)
        {
            _customerTextBox.Text = name;
        }

        public void SetShippingAddress(string address)
        {
            _shippingAddressTextBox.Text = address;
        }

        public void SetPriceList(string name)
        {
            _priceLookUpBox.Label = name;
        }

        public void SetWarehouse(string address)
        {
            _warehouseLookUpBox.Label = address;
        }

        public void SetItemCount(int count)
        {
            itemsVirtualListBox.SetListSize(count);
        }

        public int GetSelectedId()
        {
            throw new NotImplementedException();
        }

        private void AddClick(object sender, EventArgs e)
        {
            using (var pickUpProductView = new PickUpProductView(_presenter.GetPriceListId()))
            {
                if (DialogResult.OK == pickUpProductView.ShowDialog())
                {
                }
            }
        }

        #region IView

        public void ShowView()
        {
            Show();
        }

        public DialogViewResult ShowDialogView()
        {
            DialogResult dialogResult = ShowDialog();
            if (dialogResult == DialogResult.OK)
                return DialogViewResult.OK;

            return DialogViewResult.Cancel;
        }

        public void CloseView()
        {
            Close();
        }

        public void DisplayErrors(string error)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}