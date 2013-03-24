using System;
using System.Windows.Forms;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class RouteView : Form, IRouteView
    {
        private RoutePresenter _presenter;

        public RouteView()
        {
            InitializeComponent();
        }

        void _routeVirtualListBox_ItemDataNeeded(object sender, VirtualListBoxItem<RoutePoint> item)
        {
            item.Data = _presenter.GetRoutePoint(item.Index);
        }

        public void SetRoutePointCount(int count)
        {
            _routeVirtualListBox.SetListSize(count);
        }

        private void RouteView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _routeVirtualListBox.ItemDataNeeded += _routeVirtualListBox_ItemDataNeeded;
                _presenter = new RoutePresenter(this);
                _presenter.InitializeView();
            }
        }

        public void DisplayErrors(string error)
        {
            
        }

        private void _createOrderIcon_Click(object sender, EventArgs e)
        {
            var orderView = new OrderView(_presenter.GetRoutePoint(_routeVirtualListBox.SelectedIndex));
            orderView.Show();
        }
    }
}
