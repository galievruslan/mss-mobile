using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class RouteView : Form, IRouteView {
        private readonly IPresentersFactory _presentersFactory;
        private RoutePresenter _presenter;

        public RouteView(IPresentersFactory presentersFactory) {
            _presentersFactory = presentersFactory;
            InitializeComponent();
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var pointListBoxItem = item as RoutePointListBoxItem;
            if (pointListBoxItem != null) {
                pointListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                routePointListBox.ItemSelected += ItemSelected;
                routePointListBox.ItemDataNeeded += ItemDataNeeded;
                _presenter = _presentersFactory.CreateRoutePresenter(this);
                routePointListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        void ItemSelected(object sender, VirtualListBoxItem item)
        {
            _presenter.SelectItem(item.Index);
        }

        private void CreateOrderClick(object sender, EventArgs e)
        {
        }

        public void SetItemCount(int count)
        {
            //_routeVirtualListBox.SetListSize(count);
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
            throw new NotImplementedException();
        }

        #endregion
    }
}
