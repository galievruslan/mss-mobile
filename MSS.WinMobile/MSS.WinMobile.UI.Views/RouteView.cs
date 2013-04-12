using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class RouteView : Form, IRouteView
    {
        private RoutePresenter _presenter;

        public RouteView()
        {
            InitializeComponent();
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var pointListBoxItem = item as RoutePointListBoxItem;
            if (pointListBoxItem != null)
            {
                pointListBoxItem.SetData(_presenter.GetItemData(item.Index));
            }
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                _routeVirtualListBox.ItemSelected += ItemSelected;
                _routeVirtualListBox.ItemDataNeeded += ItemDataNeeded;
                _presenter = new RoutePresenter(this);
                _presenter.InitializeView();
            }
        }

        void ItemSelected(object sender, VirtualListBoxItem item)
        {
            _presenter.SelectItem(item.Index);
        }

        private void CreateOrderClick(object sender, EventArgs e)
        {
            var orderView = new OrderView(_presenter.GetSelectedItemId());
            orderView.Show();
        }

        public void SetItemCount(int count)
        {
            _routeVirtualListBox.SetListSize(count);
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
