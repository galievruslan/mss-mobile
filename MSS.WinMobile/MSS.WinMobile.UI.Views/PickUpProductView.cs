using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MSS.WinMobile.UI.Controls.ListBox.ListBoxItems;
using MSS.WinMobile.UI.Presenters.Presenters;
using MSS.WinMobile.UI.Presenters.Views;

namespace MSS.WinMobile.UI.Views
{
    public partial class PickUpProductView : Form, IPickUpProductView
    {
        private PickUpProductPresenter _presenter;
        private readonly int _orderId;

        public PickUpProductView()
        {
            InitializeComponent();
        }

        public PickUpProductView(IDictionary<string, object> args)
            :this()
        {
            if (args.ContainsKey("OrderId"))
                _orderId = (int)args["OrderId"];
        }

        private void ViewLoad(object sender, EventArgs e)
        {
            if (_presenter == null)
            {
                productsPriceListBox.ItemDataNeeded += ItemDataNeeded;
                productsPriceListBox.ItemSelected += ProductsPriceListBoxItemSelected;
                _presenter = new PickUpProductPresenter(this, _orderId);
                _presenter.InitializeView();
            }
        }

        private VirtualListBoxItem _selectedItem;
        void ProductsPriceListBoxItemSelected(object sender, VirtualListBoxItem item)
        {
            _selectedItem = item;
        }

        void ItemDataNeeded(object sender, VirtualListBoxItem item)
        {
            var productPriceListBoxItem = item as ProductPriceListBoxItem;
            if (productPriceListBoxItem != null)
            {
                productPriceListBoxItem.SetData(_presenter.GetItemData(item.Index));
            }
        }

        public void SetItemCount(int count)
        {
            productsPriceListBox.SetListSize(count);
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
                return DialogViewResult.OK;

            return DialogViewResult.Cancel;
        }

        public void CloseView()
        {
            Close();
        }

        public void DisplayErrors(string error)
        {
            
        }

        #endregion

        private void DigitButtonClick(object sender, EventArgs e)
        {
            var digitButton = sender as Button;
            if (digitButton != null)
            {
                _presenter.AddDigit(productsPriceListBox.SelectedIndex, Int32.Parse(digitButton.Text));
                _selectedItem.RefreshData();
                _selectedItem.Refresh();
            }
        }

        private void DeleteDigitButtonClick(object sender, EventArgs e)
        {
            _presenter.RemoveDigit(productsPriceListBox.SelectedIndex);
            _selectedItem.RefreshData();
            _selectedItem.Refresh();
        }

        public IDictionary<int, int> GetValues()
        {
            return _presenter.GetValues();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}