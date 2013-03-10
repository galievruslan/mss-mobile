using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Presenters;

namespace MSS.WinMobile.UI.Views
{
    public partial class RouteView : Form, IRouteView
    {
        private RoutePresenter _presenter;

        public RouteView()
        {
            InitializeComponent();
            _routeVirtualListBox.ItemDataNeeded += _routeVirtualListBox_ItemDataNeeded;
        }

        void _routeVirtualListBox_ItemDataNeeded(object sender, Controls.ListBox.IListBoxItem item)
        {
            item.Data = _presenter.GetRoutePointData(item.Index);
        }

        public void SetRoutePointCount(int count)
        {
            _routeVirtualListBox.ItemCount = count;
        }

        private void RouteView_Load(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _presenter = new RoutePresenter(this);
                _presenter.InitializeView();
            }
        }

        public void DisplayErrors(string error)
        {
            
        }

        private void _createOrderIcon_Click(object sender, EventArgs e)
        {

        }
    }
}
