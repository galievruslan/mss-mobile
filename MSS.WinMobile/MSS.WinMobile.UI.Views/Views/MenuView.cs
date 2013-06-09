using System;
using System.Drawing;
using MSS.WinMobile.Resources;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class MenuView : View, IMenuView {
        internal MenuView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;
        private readonly ILocalizator _localizator;

        public MenuView(IPresentersFactory presentersFactory, ILocalizator localizator) : this() {
            _presentersFactory = presentersFactory;
            _localizator = localizator;

            _routesLabel.Text = _localizator.Localization.GetLocalizedValue(_routesLabel.Text);
            _ordersLabel.Text = _localizator.Localization.GetLocalizedValue(_ordersLabel.Text);
            _synchronizationLabel.Text = _localizator.Localization.GetLocalizedValue(_synchronizationLabel.Text);
            _settingsLabel.Text = _localizator.Localization.GetLocalizedValue(_settingsLabel.Text);
        }

        private MenuPresenter _menuPresenter;

        private void MenuViewLoad(object sender, EventArgs e) {
            if (_menuPresenter == null) {
                _menuPresenter = _presentersFactory.CreateMenuPresenter(this);
                _menuPresenter.InitializeView();
            }
        }

        private readonly Color _selectedMenuColor = Color.MediumBlue;
        private void SynchronizationLabelClick(object sender, EventArgs e) {
            _synchronizationLabel.ForeColor = _selectedMenuColor;
            _synchronizationLabel.Font = new Font(_synchronizationLabel.Font.Name,
                                                  _synchronizationLabel.Font.Size,
                                                  FontStyle.Underline);
            _synchronizationLabel.Refresh();
            _menuPresenter.ShowSyncView();
        }

        private void RouteClick(object sender, EventArgs e) {
            _routesLabel.ForeColor = _selectedMenuColor;
            _routesLabel.Font = new Font(_routesLabel.Font.Name,
                                                  _routesLabel.Font.Size,
                                                  FontStyle.Underline);
            _routesLabel.Refresh();
            _menuPresenter.ShowRouteView();
        }

        private void SettingsLabelClick(object sender, EventArgs e) {
            _settingsLabel.ForeColor = _selectedMenuColor;
            _settingsLabel.Font = new Font(_settingsLabel.Font.Name,
                                                  _settingsLabel.Font.Size,
                                                  FontStyle.Underline);
            _settingsLabel.Refresh();
            _menuPresenter.ShowSettingsView();
        }

        private void OrdersLabelClick(object sender, EventArgs e) {
            _ordersLabel.ForeColor = _selectedMenuColor;
            _ordersLabel.Font = new Font(_ordersLabel.Font.Name,
                                                  _ordersLabel.Font.Size,
                                                  FontStyle.Underline);
            _ordersLabel.Refresh();
            _menuPresenter.ShowOrderListView();
        }

        private void UpdatesLabelClick(object sender, EventArgs e)
        {
            _updatesLabel.ForeColor = _selectedMenuColor;
            _updatesLabel.Font = new Font(_updatesLabel.Font.Name,
                                         _updatesLabel.Font.Size,
                                         FontStyle.Underline);
            _updatesLabel.Refresh();
            _menuPresenter.RunUpdater();

            _updatesLabel.ForeColor = Color.Black;
            _updatesLabel.Font = new Font(_updatesLabel.Font.Name,
                                         _updatesLabel.Font.Size,
                                         FontStyle.Regular);
        }
    }
}
