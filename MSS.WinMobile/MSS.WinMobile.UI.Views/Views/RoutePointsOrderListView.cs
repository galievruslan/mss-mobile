using System;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class RoutePointsOrderListView : View, IRoutePointsOrderListView {
        public RoutePointsOrderListView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private readonly ILocalizationManager _localizationManager;

        private RoutePointsOrderListPresenter _presenter;
        private readonly RoutePointViewModel _routePointViewModel;

        public RoutePointsOrderListView(IPresentersFactory presentersFactory,
                                        ILocalizationManager localizationManager,
                                        RoutePointViewModel routePointViewModel)
            : this() {
            _presentersFactory = presentersFactory;
            _localizationManager = localizationManager;
            _routePointViewModel = routePointViewModel;

            _orderListBox.LocalizationManager = _localizationManager;
        }

        private void OrderListViewLoad(object sender, EventArgs e) {
            if (_presenter == null) {
                _presenter = _presentersFactory.CreateRoutePointsOrderListPresenter(this, _routePointViewModel);
                _orderListBox.ItemDataNeeded += ItemDataNeeded;
                _orderListBox.ItemSelected += ItemSelected;
                _orderListBox.SetListSize(_presenter.InitializeListSize());

                ViewContainer.RegisterLeftAction(new StubAction());
                ViewContainer.RegisterRightAction(new Back(_presenter));
            }
        }

        void ItemSelected(object sender, VirtualListBoxItem item) {
            _presenter.Select(item.Index);
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

        private void DeleteOrderButtonClick(object sender, EventArgs e) {
            _presenter.DeleteOrder();
            _orderListBox.SetListSize(_presenter.InitializeListSize());
            Refresh();
        }

        private class Back : IViewAction {
            private readonly RoutePointsOrderListPresenter _presenter;
            public Back(RoutePointsOrderListPresenter presenter) {
                _presenter = presenter;
            }

            public string Caption {
                get { return "Back"; }
            }
            public void Do(object sender, EventArgs e) {
                _presenter.GoToRoute();
            }
        }
    }
}
