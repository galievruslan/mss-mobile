using System;
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

        private void SynchronizationLabelClick(object sender, EventArgs e) {
            _menuPresenter.ShowSyncView();
        }

        private void RouteClick(object sender, EventArgs e) {
            _menuPresenter.ShowRouteView();
        }
    }
}
