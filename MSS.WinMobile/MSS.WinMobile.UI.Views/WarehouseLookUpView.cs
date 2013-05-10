﻿using System;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class WarehouseLookUpView : Form, IWarehouseLookUpView
    {
        private WarehouseLookUpPresenter _presenter;

        public WarehouseLookUpView()
        {
            InitializeComponent();
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                //warehouseListBox.ItemDataNeeded += ItemDataNeeded;
                //warehouseListBox.ItemSelected += ItemSelected;
                //_presenter = new WarehouseLookUpPresenter(this);
                //_presenter.InitializeView();
            }
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            //var priceListListBoxItem = item as WarehouseListBoxItem;
            //if (priceListListBoxItem != null)
            //{
            //    priceListListBoxItem.SetData(_presenter.GetItemData(item.Index));
            //}
        }

        private void CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public void SetItemCount(int count)
        {
            //warehouseListBox.SetListSize(count);
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
        }

        public void DisplayErrors(string error)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}