using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
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
                routeViewModelBindingSource.DataSource = _presenter.Initialize();
                routePointListBox.SetListSize(_presenter.InitializeListSize());
                datePicker.ValueChanged += DateChanged;
            }
        }

        void ItemSelected(object sender, VirtualListBoxItem item) {
            _presenter.Select(item.Index);
        }

        private void CreateOrderClick(object sender, EventArgs e)
        {
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

        public void DisplayErrors(string error) {
            _notification.Critical = true;
            _notification.Text = error;
            _notification.Visible = true;
        }

        #endregion

        private void CreateRouteOnDateButtonClick(object sender, EventArgs e) {
            routeViewModelBindingSource.EndEdit();
            _presenter.CreateRouteOnDate();
            routePointListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void DateChanged(object sender, EventArgs e) {
            var routeViewModel = routeViewModelBindingSource.Current as RouteViewModel;
            if (routeViewModel != null)
                routeViewModel.Date = datePicker.Value;
            routeViewModelBindingSource.EndEdit();
            _presenter.GetRouteOnDate();
            routePointListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void CreateRoutePointButtonClick(object sender, EventArgs e) {
            if (_presenter.AddRoutePoint()) {
                routePointListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        private void ListOrdersButtonClick(object sender, EventArgs e)
        {
            _presenter.GoToOrderList();
        }
    }
}
