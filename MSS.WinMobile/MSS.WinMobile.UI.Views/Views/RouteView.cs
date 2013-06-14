using System;
using MSS.WinMobile.Resources;
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
        private readonly ILocalizationManager _localizationManager;
        private readonly RouteViewModel _routeViewModel;

        public RouteView(IPresentersFactory presentersFactory, ILocalizationManager localizationManager,
                         RouteViewModel routeViewModel)
            : this() {
            _presentersFactory = presentersFactory;
            _localizationManager = localizationManager;
            _routeViewModel = routeViewModel;

            datePicker.CustomFormat = _localizationManager.Localization.GetLocalizedValue("dateformat");
            routePointListBox.LocalizationManager = _localizationManager;
        }

        private RoutePresenter _routePresenter;
        private RouteViewModel _viewModel;
        private void RouteViewLoad(object sender, EventArgs e) {
            if (_routePresenter == null) {
                routePointListBox.ItemSelected += ItemSelected;
                routePointListBox.ItemDataNeeded += ItemDataNeeded;
                
                _routePresenter = _presentersFactory.CreateRoutePresenter(this, _routeViewModel);
                _viewModel = _routePresenter.Initialize();
                ViewContainer.RegisterLeftAction(new StubAction());
                ViewContainer.RegisterRightAction(new Back(_routePresenter));

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

        private void DeleteRoutePointButtonClick(object sender, EventArgs e) {
            _routePresenter.DeleteRoutePoint();
            routePointListBox.SetListSize(_routePresenter.InitializeListSize());
            Refresh();
        }

        private void ChangeStatusButtonClick(object sender, EventArgs e) {
            _routePresenter.GoToStatusChanging();
        }

        private class Back : IViewAction {
            private readonly RoutePresenter _routePresenter;
            public Back(RoutePresenter routePresenter) {
                _routePresenter = routePresenter;
            }

            public string Caption {
                get { return "Back"; }
            }
            public void Do(object sender, EventArgs e) {
                _routePresenter.GoToMenuView();
            }
        }
    }
}
