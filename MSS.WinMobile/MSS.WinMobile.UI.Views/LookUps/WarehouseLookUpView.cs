using System;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Views.LookUps {
    public partial class WarehouseLookUpView : LookUpView, IWarehouseLookUpView 
    {
        private WarehouseLookUpPresenter _presenter;
        private readonly IPresentersFactory _presentersFactory;

        public WarehouseLookUpView() {
            InitializeComponent();
        }

        public WarehouseLookUpView(IPresentersFactory presentersFactory) {
            InitializeComponent();
            _presentersFactory = presentersFactory;
        }

        private void ViewLoad(object sender, EventArgs e) {
            if (_presenter == null) {
                _warehouseListBox.ItemDataNeeded += ItemDataNeeded;
                _warehouseListBox.ItemSelected += ItemSelected;
                _presenter = _presentersFactory.CreateWarehouseLookUpPresenter(this);
                _warehouseListBox.SetListSize(_presenter.InitializeListSize());
            }
        }

        private void ItemSelected(object sender, VirtualListBoxItem item) {
            _presenter.Select(item.Index);
        }

        private void ItemDataNeeded(object sender, VirtualListBoxItem item) {
            var warehouseListBoxItem = item as WarehouseListBoxItem;
            if (warehouseListBoxItem != null) {
                warehouseListBoxItem.ViewModel = _presenter.GetItem(item.Index);
            }
        }

        public WarehouseViewModel SelectedWarehouse {
            get { return _presenter.SelectedModel; }
        }

        private void DoSearchClick(object sender, string criteria) {
            _presenter.Search(criteria);
            _warehouseListBox.SetListSize(_presenter.InitializeListSize());
        }

        private void ClearSearchClick(object sender) {
            _presenter.ClearSearch();
            _warehouseListBox.SetListSize(_presenter.InitializeListSize());
        }
    }
}