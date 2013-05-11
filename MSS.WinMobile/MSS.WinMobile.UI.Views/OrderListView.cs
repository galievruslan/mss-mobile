using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class OrderListView : Form, IOrderListView
    {
        public OrderListView()
        {
            InitializeComponent();
        }

        private OrderListPresenter _presenter;
        private readonly IPresentersFactory _presentersFactory;
        private readonly RoutePointViewModel _routePointViewModel;

        public OrderListView(IPresentersFactory presentersFactory, RoutePointViewModel routePointViewModel)
        {
            InitializeComponent();
            _presentersFactory = presentersFactory;
            _routePointViewModel = routePointViewModel;
        }

        private void CreateRoutePointButtonClick(object sender, EventArgs e)
        {

        }

        private void CreateOrderClick(object sender, EventArgs e)
        {
            _presenter.CreateOrder();
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateOrderListPresenter(this, _routePointViewModel);
                _orderListBox.ItemDataNeeded += ItemDataNeeded;
                _orderListBox.ItemSelected += ItemSelected;
                _orderListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        void ItemSelected(object sender, Controls.ListBox.ListBoxItems.VirtualListBoxItem item)
        {
            _presenter.Select(item.Index);
        }

        void ItemDataNeeded(object sender, Controls.ListBox.ListBoxItems.VirtualListBoxItem item)
        {
            var orderListBoxItem = item as OrderListBoxItem;
            if (orderListBoxItem != null)
            {
                orderListBoxItem.ViewModel = _presenter.GetItem(item.Index);
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
                return DialogViewResult.Ok;

            return DialogViewResult.Cancel;
        }

        public void CloseView()
        {
            Close();
            Dispose();
        }

        public void DisplayErrors(string error)
        {
        }

        #endregion

    }
}