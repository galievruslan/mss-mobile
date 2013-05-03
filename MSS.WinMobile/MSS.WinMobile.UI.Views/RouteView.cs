using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class RouteView : Form, IRouteView {
        private readonly PresentersFactory _presentersFactory;
        private RoutePresenter _presenter;

        public RouteView(PresentersFactory presentersFactory) {
            _presentersFactory = presentersFactory;
            InitializeComponent();
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            //var pointListBoxItem = item as RoutePointListBoxItem;
            //if (pointListBoxItem != null)
            //{
            //    pointListBoxItem.SetData(_presenter.GetItemData(item.Index));
            //}
        }

        private RouteViewModel _viewModel;
        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                routePointListBox.ItemSelected += ItemSelected;
                routePointListBox.ItemDataNeeded += ItemDataNeeded;
                _presenter = _presentersFactory.CreateRoutePresenter(this);
                _viewModel = _presenter.InitializeView();
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
