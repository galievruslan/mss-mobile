﻿using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.Concret.ListBoxItems;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Presenters.LookUps;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using MSS.WinMobile.UI.Presenters.Views.LookUps;

namespace MSS.WinMobile.UI.Views.LookUps {
    public partial class WarehouseLookUpView : Form, IWarehouseLookUpView {
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

        #region IView

        public void ShowView() {
            Show();
        }

        public DialogViewResult ShowDialogView() {
            DialogResult dialogResult = ShowDialog();
            if (dialogResult == DialogResult.OK)
                return DialogViewResult.Ok;

            return DialogViewResult.Cancel;
        }

        public void CloseView() {
            Close();
        }

        public void DisplayErrors(string error) {
            throw new NotImplementedException();
        }

        #endregion

        public WarehouseViewModel SelectedWarehouse {
            get { return _presenter.SelectedModel; }
        }

        private void okButton_Click(object sender, EventArgs e) {
            if (_presenter.LookUp())
                DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            _presenter.Cancel();
        }
    }
}