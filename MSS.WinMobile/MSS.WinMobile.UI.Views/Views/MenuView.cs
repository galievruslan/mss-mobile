﻿using System;
using System.Drawing;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views.Views {
    public partial class MenuView : View, IMenuView {
        public MenuView() {
            InitializeComponent();
        }

        private readonly IPresentersFactory _presentersFactory;

        public MenuView(IPresentersFactory presentersFactory) {
            InitializeComponent();
            _presentersFactory = presentersFactory;
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
    }
}
