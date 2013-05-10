using System;
using System.Globalization;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
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
                //itemsVirtualListBox.ItemDataNeeded += itemsVirtualListBox_ItemDataNeeded;
                //itemsVirtualListBox.ItemSelected += itemsVirtualListBox_ItemSelected;
                //_presenter = new OrderPresenter(this, _routePointId);
                //_presenter.InitializeView();
            }
        }

        void itemsVirtualListBox_ItemSelected(object sender, VirtualListBoxItem item)
        {
            //throw new NotImplementedException();
        }

        void itemsVirtualListBox_ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            //_presenter.GetItemData(item.Index);
            //var orderItemListBoxItem = item as OrderItemListBoxItem;
            //if (orderItemListBoxItem != null)
            //{
            //    orderItemListBoxItem.SetData(_presenter.GetItemData(item.Index));
            //}
        }

        private void PriceListLookUp(Controls.LookUpBox sender)
        {
            using (var priceListLookUpView = new PriceListLookUpView())
            {
                if (DialogResult.OK == priceListLookUpView.ShowDialog())
                {
                    //int priceListId = priceListLookUpView.
                    //_presenter.SetPriceList(priceListId);
                }
            }
        }

        private void WarehouseLookUp(Controls.LookUpBox sender)
        {
            using (var warehouseLookUpView = new WarehouseLookUpView())
            {
                if (DialogResult.OK == warehouseLookUpView.ShowDialog())
                {
                    //int warehouseListId = warehouseLookUpView.GetSelectedId();
                    //_presenter.SetWarehouse(warehouseListId);
                }
            }
        }

        public void SetItemCount(int count)
        {
            //itemsVirtualListBox.SetListSize(count);
        }

        private void AddClick(object sender, EventArgs e)
        {
            _presenter.PickUpProducts();
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
                return DialogViewResult.Ok;

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

        private void ResetButtonClick(object sender, EventArgs e)
        {

        }

        private void LookUpButtonClick(object sender, EventArgs e)
        {

        }
    }
}