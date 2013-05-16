using System;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class RouteView : View, IRouteView {
        public RouteView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private readonly RouteViewModel _routeViewModel;
        public RouteView(IPresentersFactory presentersFactory, RouteViewModel routeViewModel) {
            InitializeComponent();
            _presentersFactory = presentersFactory;
            _routeViewModel = routeViewModel;
        }

        private RoutePresenter _routePresenter;
        private RouteViewModel _viewModel;
        private void RouteViewLoad(object sender, EventArgs e) {
            if (_routePresenter == null) {
                routePointListBox.ItemSelected += ItemSelected;
                routePointListBox.ItemDataNeeded += ItemDataNeeded;

                _routePresenter = _presentersFactory.CreateRoutePresenter(this, _routeViewModel);
                _viewModel = _routePresenter.Initialize();
                datePicker.Value = _viewModel.Date;
                routePointListBox.SetListSize(_routePresenter.InitializeListSize());
                datePicker.ValueChanged += DateChanged;
            }
        }

        private VirtualListBoxItem _selectedListItem;
        private void ItemSelected(object sender, VirtualListBoxItem item) {
            _routePresenter.Select(item.Index);
            _selectedListItem = item;
        }

        private void ItemDataNeeded(object sender, VirtualListBoxItem item) {
            var pointListBoxItem = item as RoutePointListBoxItem;
            if (pointListBoxItem != null) {
                pointListBoxItem.ViewModel = _routePresenter.GetItem(item.Index);
            }
        }

        private void DateChanged(object sender, EventArgs e) {
            _viewModel.Date = datePicker.Value;
            _routePresenter.GetRouteOnDate();
            routePointListBox.SetListSize(_routePresenter.InitializeListSize());
        }

        private void ListOrdersButtonClick(object sender, EventArgs e) {
            _routePresenter.GoToOrderList();
        }

        private void CreateRoutePointButtonClick(object sender, EventArgs e) {
            _routePresenter.GoToAddRoutePoint();
        }

        private void CreateOrderClick(object sender, EventArgs e) {
            _routePresenter.GoToCreateOrder();
        }

        private void CreateRouteOnDateButtonClick(object sender, EventArgs e) {
            _routePresenter.CreateRouteOnDate();
            _routePresenter.GetRouteOnDate();
            routePointListBox.SetListSize(_routePresenter.InitializeListSize());
        }

        private void CloseButtonClick(object sender, EventArgs e) {
            _routePresenter.GoToMenuView();
        }
    }
}
