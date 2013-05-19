using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class OrderListView : View, IOrderListView {
        public OrderListView() {
            InitializeComponent();
        }
        
        private readonly IPresentersFactory _presentersFactory;

        private OrderListPresenter _presenter;
        private readonly RoutePointViewModel _routePointViewModel;
        public OrderListView(IPresentersFactory presentersFactory, RoutePointViewModel routePointViewModel) {
            InitializeComponent();
            _presentersFactory = presentersFactory;
            _routePointViewModel = routePointViewModel;
        }

        private void OrderListViewLoad(object sender, EventArgs e) {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateOrderListPresenter(this, _routePointViewModel);
                _orderListBox.ItemDataNeeded += ItemDataNeeded;
                _orderListBox.ItemSelected += ItemSelected;
                _orderListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        private VirtualListBoxItem _selectedListItem;
        void ItemSelected(object sender, VirtualListBoxItem item) {
            _presenter.Select(item.Index);
            _selectedListItem = item;
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item) {
            var orderListBoxItem = item as OrderListBoxItem;
            if (orderListBoxItem != null) {
                orderListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        private void EditOrderClick(object sender, EventArgs e) {
            _presenter.EditOrder();
        }

        private void CreateOrderClick(object sender, EventArgs e) {
            _presenter.CreateOrder();
        }

        private void CloseButtonClick(object sender, EventArgs e) {
            _presenter.GoToRoute();
        }

        private void _deleteOrderButton_Click(object sender, EventArgs e) {
            _presenter.DeleteOrder();
            _orderListBox.SetListSize(_presenter.InitializeListSize());
            Refresh();
        }
    }
}
